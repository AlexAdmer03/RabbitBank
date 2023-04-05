using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Models;
using RabbitBank.Services;

namespace RabbitBank.Pages.ShowCountries
{
    public class FinlandDetailsModel : PageModel
    {
        private readonly ICountryService _countryService;

        public FinlandDetailsModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public List<CustomerModel> TopTenFin { get; set; }
        public void OnGet(string country)
        {
            TopTenFin = _countryService.GetTopTenCustomers("Finland");
        }
    }
}
