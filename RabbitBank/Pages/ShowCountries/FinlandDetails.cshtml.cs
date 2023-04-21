using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Pages.ViewModels;
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
        public int AccountId { get; set; }
        public void OnGet(string country, int customerId)
        {
            TopTenFin = _countryService.GetTopTenCustomers("Finland");
            AccountId = customerId;
        }
    }
}
