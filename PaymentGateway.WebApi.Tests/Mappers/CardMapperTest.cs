using FluentAssertions;
using PaymentGateway.Service.Dom;
using PaymentGateway.WebApi.Mappers;
using PaymentGateway.WebApi.Models;
using Xunit;

namespace PaymentGateway.WebApi.Tests.Mappers
{
    public class CardMapperTest
    {
        [Fact]
        public void CardMapperMapsFilledCardDtoToCard()
        {
            var cardDto = new CardDto
            {
                CardNumber = "1234123412341234",
                Cvv = 123,
                ExpiryMonth = 12,
                ExpiryYear = 20
            };

            var mapper = new CardMapper();

            var card = mapper.Map(cardDto);

            card.Should().NotBeNull();
            card.Cvv.Should().Be(123);
            card.CardNumber.Should().Be("1234123412341234");
            card.ExpiryMonth.Should().Be(12);
            card.ExpiryYear.Should().Be(20);
        }

        [Fact]
        public void CardMapperMapsNullCardDtoToEmptyCard()
        {
            var mapper = new CardMapper();

            var card = mapper.Map((CardDto)null);

            card.Should().NotBeNull();
            card.Should().BeEquivalentTo(Card.Empty);
        }

        [Fact]
        public void CardMapperMapsFilledCardToCardDto()
        {
            var card = new Card
            {
                CardNumber = "1234123412341234",
                Cvv = 123,
                ExpiryMonth = 12,
                ExpiryYear = 20
            };

            var mapper = new CardMapper();

            var cardDto = mapper.Map(card);

            cardDto.Should().NotBeNull();
            cardDto.Cvv.Should().Be(123);
            cardDto.CardNumber.Should().Be("1234123412341234");
            cardDto.ExpiryMonth.Should().Be(12);
            cardDto.ExpiryYear.Should().Be(20);
        }

        [Fact]
        public void CardMapperMapsNullCardToEmptyCardDto()
        {
            var mapper = new CardMapper();

            var card = mapper.Map((Card)null);

            card.Should().NotBeNull();
            card.Should().BeEquivalentTo(CardDto.Empty);
        }

    }
}