using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.BankAppData;
using RabbitBank.Services;

namespace RabbitBank.Pages.Customers
{
    [Authorize(Roles = "Cashier")]
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

        [BindProperty(SupportsGet = true)] public int PageNumber { get; set; } = 1;

        public List<Customer> Customers { get; set; }

        public int TotalPages { get; set; }


        [BindProperty(SupportsGet = true)]
        public string SortColumn { get; set; } = "CustomerNumber";

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "asc";

        public void OnGet(int pageSize = 50)
        {
            int totalCustomers = _customerService.GetTotalCustomersCount(SearchTerm, City);
            TotalPages = (int)Math.Ceiling((double)totalCustomers / pageSize);
            Customers = _customerService.GetCustomers(SearchTerm, City, PageNumber, pageSize, SortColumn, SortOrder);
        }
    }
}
