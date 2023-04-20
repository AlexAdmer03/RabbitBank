namespace RabbitBank.Pages.ViewModels
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Gender { get; set; }
        public string Givenname { get; set; }
        public string Surname { get; set; }
        public string Streetaddress { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
        public string Countrycode { get; set; }
        public DateTime Birthday { get; set; }
        public string NationalId { get; set; }
        public decimal Balance { get; set; }
        public int TelephoneCountryCode { get; set; }
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }
    }
}
