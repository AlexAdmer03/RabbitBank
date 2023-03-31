using RabbitBank.Models;

namespace RabbitBank.Services
{
    public interface IindexService
    {
        List<CountriesModel> GetCountriesData();
    }
}
