using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.BankAppData;
using RabbitBank.Services;

namespace RabbitBank.Pages.Customers
{
    public class CustomerListModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public CustomerListModel (ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string City { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;


        public List<Customer> Customers { get; set; }

        public void OnGet(int PageSize)
        {
            Customers = _customerService.GetCustomers(SearchTerm, City, PageNumber, PageSize);
        }
    }
}
