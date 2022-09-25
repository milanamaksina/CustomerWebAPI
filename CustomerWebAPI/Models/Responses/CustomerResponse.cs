namespace CustomerWebAPI.Models.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? TotalPurchasesAmount { get; set; }
        public string Notes { get; set; }
    }
}
