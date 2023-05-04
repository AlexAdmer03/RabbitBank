using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Services;
using System.ComponentModel.DataAnnotations;

namespace RabbitBank.Pages.Transactions
{
    public class WithdrawModel : PageModel
    {
        private readonly ITransactionsService _transactionsService;

        public WithdrawModel(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [BindProperty]
        public int AccountId { get; set; }

        [BindProperty]
        [Required]
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

            var result = _transactionsService.Withdraw(AccountId, Amount);
            if (result == ITransactionsService.ErrorCodes.OK)
            {
                return RedirectToPage("/Transactions/Success", new { accountId = AccountId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing the withdrawal.");
                return Page();
            }
        }
    }
}
