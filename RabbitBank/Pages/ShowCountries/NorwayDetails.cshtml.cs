using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Models;
using RabbitBank.Services;

namespace RabbitBank.Pages.ShowCountries
{
    public class NorwayDetailsModel : PageModel
    {
        private readonly ICountryService _countryService;

        public NorwayDetailsModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public List<CustomerModel> TopTenNor { get; set; }
        public void OnGet(string country)
        {
            TopTenNor = _countryService.GetTopTenCustomers("Norway");
        }
    }
}