using System.Collections.Generic;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Service;
using PaymentGateway.Service.Clients;
using PaymentGateway.Service.Dom;
using PaymentGateway.Service.Mappers;
using PaymentGateway.WebApi.Auth;
using PaymentGateway.WebApi.Mappers;
using PaymentGateway.WebApi.Models;
using PaymentGateway.WebApi.Validators;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;
using PaymentMapper = PaymentGateway.WebApi.Mappers.PaymentMapper;

namespace PaymentGateway.WebApi
{
    public class Startup
    {
        private readonly Container _container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddFluentValidation();
            services.AddMvcCore().AddMetricsCore();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.UseSimpleInjectorAspNetRequestScoping(_container);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Payment GateWay Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    In = "header",
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }}
                });
            });

            services.AddSimpleInjector(_container, options =>
            {
                options.AddAspNetCore()
                       .AddControllerActivation();
            });

            string authority = Configuration["Auth0:Authority"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = authority;
                options.Audience = Configuration["Auth0:Audience"];
            });
    
            services.AddAuthorization(options =>
            {
                options.AddPolicy("read-write:test-scope",
                    policy => policy.Requirements.Add(new ScopeRequirement("read-write:test-scope", authority)));
            });

            services.AddSingleton<IAuthorizationHandler, PaymentGatewayAuthorizationHandler>();
            
            services.AddTransient<IValidator<CardDto>, CardDtoValidator>();
            services.AddTransient<IValidator<PaymentRequestDto>, PaymentRequestDtoValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSimpleInjector(_container);
            
            RegisterDependencies();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Gateway Api V1");
            });
        }

        private void RegisterDependencies()
        {
            _container.Register<IMapper<PaymentRequestDto, PaymentRequest>, PaymentRequestDtoMapper>(Lifestyle.Scoped);
            _container.Register<IMapper<PaymentResponse, PaymentResponseDto>, PaymentResponseMapper>(Lifestyle.Scoped);
            _container.Register<IMapper<Payment, PaymentDto>, PaymentMapper>(Lifestyle.Scoped);
            _container.Register<IMapper<CardDto, Card>, CardMapper>(Lifestyle.Scoped);
            _container.Register<IMapper<Card, CardDto>, CardMapper>(Lifestyle.Scoped);

            _container.Register<IPaymentMapper, Service.Mappers.PaymentMapper>(Lifestyle.Scoped);

            _container.Register<IPaymentService, PaymentService>(Lifestyle.Scoped);
            _container.RegisterSingleton<IPaymentRepository, PaymentRepository>();

            _container.Register<IBankClient, BankClientMock>(Lifestyle.Scoped);
        }

    }
}