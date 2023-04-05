using RabbitBank.Models;

namespace RabbitBank.Services
{
    public interface ICountryService
    {
        List<CountriesModel> GetCountriesData();
        List<CustomerModel> GetTopTenCustomers(string country);
    }
}
