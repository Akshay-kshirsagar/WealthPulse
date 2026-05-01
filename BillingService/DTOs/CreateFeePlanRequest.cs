namespace BillingService.DTOs
{
    public class CreateFeePlanRequest
    {
        public int ClientId { get; set; }
        public string PlanName { get; set; } = "";
        public string FeeType { get; set; } = "Flat";
        public decimal FlatAmount { get; set; }
        public decimal PercentageRate { get; set; }
        public string Frequency { get; set; } = "Monthly";
    }
}
