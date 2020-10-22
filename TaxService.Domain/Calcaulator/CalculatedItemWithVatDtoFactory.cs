namespace TaxService.Domain.Calcaulator
{
    using Core;
    using Model.Api.Calcualte;

    public interface ICalculatedVatItemDtoFactory
    {
        CalculatedItemWithVatDto Create(CalculatePostModel model, int vatRate);
    }

    [RegisterScoped]
    public class CalculatedItemWithVatDtoFactory : ICalculatedVatItemDtoFactory
    {
        public CalculatedItemWithVatDto Create(CalculatePostModel model, int vatRate)
        {
            var output = new CalculatedItemWithVatDto();
            output.Key = model.Key;
            output.Amount = model.Amount;
            output.SingleItemPrice = model.SingleItemPrice;
            var vat = (decimal) vatRate / 100;
            output.VatRate = vatRate;
            output.SingleItemVatValue = model.SingleItemPrice * vat;
            output.TotalPriceWithVat = (output.SingleItemPrice + output.SingleItemVatValue) * output.Amount;
            return output;
        }
    }
}