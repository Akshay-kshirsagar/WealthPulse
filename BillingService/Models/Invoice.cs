namespace BillingService.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string InvoiceNo { get; set; } = "";

        public decimal Amount { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; } = "Pending"; // Pending/Paid/Overdue

        public DateTime? PaidDate { get; set; }
    }
}
