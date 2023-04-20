using RabbitBank.Models;
using RabbitBank.Pages.ViewModels;

namespace RabbitBank.Services
{
    public interface ICountryService
    {
        List<CountriesModel> GetCountriesData();
        List<CustomerModel> GetTopTenCustomers(string country);
    }
}
