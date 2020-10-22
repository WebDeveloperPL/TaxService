namespace TaxService.Model.Api.Calcualte
{
    public class CalculatePostModel
    {
        public string Key { get; set; }
        public int Amount { get; set; }
        public decimal SingleItemPrice { get; set; }
    }
}