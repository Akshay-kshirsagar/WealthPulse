namespace BillingService.Models
{
    public class FeePlan
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string PlanName { get; set; } = "";

        public string FeeType { get; set; } = "Flat"; // Flat / Percentage

        public decimal FlatAmount { get; set; }

        public decimal PercentageRate { get; set; }

        public string Frequency { get; set; } = "Monthly"; // Monthly/Quarterly/Yearly

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
