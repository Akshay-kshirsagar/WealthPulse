namespace ClientService.DTOs
{
    public class CreateClientRequest
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string PAN { get; set; } = "";
        public DateTime? DateOfBirth { get; set; }
        public string RiskProfile { get; set; } = "Moderate";
        public string AdvisorCode { get; set; } = "";
    }
}
