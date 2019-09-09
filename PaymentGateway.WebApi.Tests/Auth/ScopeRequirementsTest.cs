using System;
using FluentAssertions;
using PaymentGateway.WebApi.Auth;
using Xunit;

namespace PaymentGateway.WebApi.Tests.Auth
{
    public class ScopeRequirementsTest
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("",   null)]
        public void ScopeRequirementCtorThrowsExceptionOnNullArgument(string scope, string issuer)
        {
            Action act = () => new ScopeRequirement(null, string.Empty);
            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [InlineData("test-scope", "test-issuer")]
        [InlineData("", "")]
        public void ScopeHoldsCorrectDataOfCtor(string testScope, string testIssuer)
        {
            var hasScopeRequirement = new ScopeRequirement(testScope, testIssuer);
            
            hasScopeRequirement.Issuer.Should().Be(testIssuer);
            hasScopeRequirement.Scope.Should().Be(testIssuer);
        }
    }
}