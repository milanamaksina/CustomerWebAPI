namespace CustomerWebAPI.Models.Requests
{
    public class AddressUpdateRequestcs
    {
        public int CustomerId { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressType { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
