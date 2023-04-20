namespace RabbitBank.Models
{
    public class CountriesModel
    {
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalAccounts { get; set; }
        public decimal TotalBalance { get; set; }
    }
}
