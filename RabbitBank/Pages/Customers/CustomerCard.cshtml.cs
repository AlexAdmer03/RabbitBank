using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Pages.ViewModels;
using RabbitBank.Services;
using System.Data;

namespace RabbitBank.Pages.Customers
{
    [Authorize(Roles = "Cashier")]
    public class CustomerCardModel : PageModel
    {
        private readonly ICardService _cardService;

        public CustomerCardModel(ICardService cardService)
        {
            _cardService = cardService;
        }

        [BindProperty(SupportsGet = true)]
        public int CustomerId { get; set; }

        public CustomerModel CustomerCard { get; private set; }

        public void OnGet()
        {
            CustomerCard = _cardService.GetCustomerCard(CustomerId);
        }
    }
}
