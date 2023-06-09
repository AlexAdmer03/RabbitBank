using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Pages.ViewModels;
using RabbitBank.Services;


namespace RabbitBank.Pages.ShowCountries
{
    public class SwedenDetailsModel : PageModel
    {
        private readonly ICountryService _countryService;

        public SwedenDetailsModel(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public List<CustomerModel> TopTenSwe { get; set; }
        public int AccountId { get; set; }

        public void OnGet(string country, int customerId)
        {
            TopTenSwe = _countryService.GetTopTenCustomers("Sweden");
            AccountId = customerId;

        }
    }
}
