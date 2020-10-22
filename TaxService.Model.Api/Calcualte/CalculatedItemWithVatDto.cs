namespace TaxService.Model.Api.Calcualte
{
    public class CalculatedItemWithVatDto : CalculatePostModel
    {
        public int VatRate { get; set; }
        public decimal SingleItemVatValue { get; set; }
        public decimal TotalPriceWithVat { get; set; }
    }
}