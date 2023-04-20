using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Models;
using RabbitBank.Pages.ViewModels;
using RabbitBank.Services;

namespace RabbitBank.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICountryService _indexService;
        public IndexModel(ICountryService indexService)
        {
            _indexService = indexService;
        }
        

        public List<CountriesModel> DataFromCountriesTotal { get; set; }

        public void OnGet()
        {
            DataFromCountriesTotal = _indexService.GetCountriesData();
        }
    }
}