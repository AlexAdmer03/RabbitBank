using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Pages.ViewModels;
using RabbitBank.Services;

namespace RabbitBank.Pages.ShowCountries
{
    public class DenmarkDetailsModel : PageModel
    {
        private readonly ICountryService _countryService;

        public DenmarkDetailsModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public List<CustomerModel> TopTenDen { get; set; }
        public int AccountId { get; set; }
        public void OnGet(string country, int customerId)
        {
            TopTenDen = _countryService.GetTopTenCustomers("Denmark");
            AccountId = customerId;
        }
    }
}
