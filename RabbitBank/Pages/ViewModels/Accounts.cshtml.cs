using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RabbitBank.Pages.ViewModels
{
    public class AccountsModel : PageModel
    {
        public int AccaountId { get; set; }
        public string Frequency { get; set; }
        public DateTime Created { get; set; }
        public double Balance { get; set; }
        public void OnGet()
        {
        }
    }
}
