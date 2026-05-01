namespace ClientService.DTOs
{
    public class UpdateClientRequest
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string RiskProfile { get; set; } = "Moderate";
        public bool IsActive { get; set; }
    }
}
