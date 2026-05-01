namespace ClientService.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string ClientCode { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";

        public string PAN { get; set; } = "";
        public DateTime? DateOfBirth { get; set; }

        public string RiskProfile { get; set; } = "Moderate";
        public string AdvisorCode { get; set; } = "";

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
