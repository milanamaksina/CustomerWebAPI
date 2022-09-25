namespace CustomerWebAPI.Models
{
    public class CustomerCreateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? TotalPurchasesAmount { get; set; }
        public string Notes { get; set; }
    }
}
