using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace RabbitBank.Pages.Customer_Crud
{
    [Authorize(Roles = "Cashier")]
    public class ReadModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
