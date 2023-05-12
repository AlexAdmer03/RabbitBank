using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Services;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RabbitBank.Pages.Transactions
{
    [Authorize(Roles = "Cashier")]
    public class DepositModel : PageModel
    {
        private readonly ITransactionsService _transactionsService;

        public DepositModel(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [BindProperty]
        public int AccountId { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Amount must be in the range 100 - 1000")]
        [Range(100, 10000)]
        public decimal Amount { get; set; }

        public IActionResult OnGet(int accountId)
        {
            AccountId = accountId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _transactionsService.Deposit(AccountId, Amount);
            if (result == ITransactionsService.ErrorCodes.OK)
            {
                return RedirectToPage("/Transactions/SuccessPage", new { accountId = AccountId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing the deposit.");
                return Page();
            }
        }
    }
}
