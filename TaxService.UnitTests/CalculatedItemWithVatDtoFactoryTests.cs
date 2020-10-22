using NUnit.Framework;

namespace TaxService.UnitTests
{
    using Domain.Calcaulator;
    using Model.Api.Calcualte;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(100, 10, 10)]
        [TestCase(100, 0, 0)]
        [TestCase(0, 10, 0)]
        [TestCase(230.89, 10, 23.089)]
        public void Should_calculate_price_with_vat(decimal singleItemPrice, int vat, decimal expectedVatAmount)
        {
            var sut = new CalculatedItemWithVatDtoFactory();
            var model = new CalculatePostModel
            {
                SingleItemPrice = singleItemPrice,
                Key = "key",
                Amount = 1
            };

            var result = sut.Create(model, vat);
            Assert.AreEqual(expectedVatAmount, result.SingleItemVatValue);
        }

        [TestCase(100, 10, 2, 220)]
        [TestCase(0, 10, 2, 0)]
        [TestCase(100, 0, 2, 200)]
        [TestCase(100.22, 10, 2, 220.484)]
        public void Should_calculate_total_price(decimal singleItemPrice, int vat, int count, decimal expectedVatAmount)
        {
            var sut = new CalculatedItemWithVatDtoFactory();
            var model = new CalculatePostModel
            {
                SingleItemPrice = singleItemPrice,
                Key = "key",
                Amount = count
            };

            var result = sut.Create(model, vat);
            Assert.AreEqual(expectedVatAmount, result.TotalPriceWithVat);
        }
       
        [TestCase(10)]
        public void Should_map_request_data(int vat)
        {
            var sut = new CalculatedItemWithVatDtoFactory();
            var model = new CalculatePostModel
            {
                SingleItemPrice = 1,
                Key = "key",
                Amount = 2
            };

            var result = sut.Create(model, vat);
            Assert.AreEqual(result.VatRate, vat);
            Assert.AreEqual(result.Amount, model.Amount);
            Assert.AreEqual(result.SingleItemPrice, model.SingleItemPrice);
        }
    }
}