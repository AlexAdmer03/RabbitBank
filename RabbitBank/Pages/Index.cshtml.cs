using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RabbitBank.BankAppData;
using RabbitBank.Pages.ViewModels;

namespace RabbitBank.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //private readonly BankAppDataContext _dbContext;

        //public IndexModel(BankAppDataContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<CustomerModel> Customers { get; set; }

        public void OnGet()
        {
           
        }
    }
}