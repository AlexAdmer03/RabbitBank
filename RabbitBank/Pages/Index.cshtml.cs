using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RabbitBank.BankAppData;
using RabbitBank.Models;
using RabbitBank.Pages.ViewModels;
using RabbitBank.Services;

namespace RabbitBank.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IindexService _indexService;
        public IndexModel(IindexService indexService)
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