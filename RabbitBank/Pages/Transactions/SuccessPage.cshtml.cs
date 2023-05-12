using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace RabbitBank.Pages.Transactions
{
    [Authorize(Roles = "Cashier")]
    public class SuccessPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
