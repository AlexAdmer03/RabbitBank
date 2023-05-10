using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Services;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RabbitBank.Pages.Transactions
{
    public class TransferModel : PageModel
    {

        private readonly ITransactionsService _transactionsService;

        public TransferModel(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }


        [BindProperty]
        [Display(Name = "Sending Account ID")]
        public int SendingAccountId { get; set; }

        [BindProperty(SupportsGet = true)]
        [Display(Name = "Account ID")]
        public int? AccountId { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "You must enter a receiving account ID")]
        [Display(Name = "Receiving Account ID")]
        public int ReceivingAccountId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Amount must be in the range 100 - 1000")]
        [Display(Name = "Amount")]
        [Range(100, 10000, ErrorMessage = "Amount must be between 100 and 10,000.")]
        public decimal Amount { get; set; }

        [BindProperty]
        [Display(Name = "Comments")]
        public string Comments { get; set; }

        public void OnGet()
        {
            if (AccountId.HasValue)
            {
                SendingAccountId = AccountId.Value;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _transactionsService.Transfer(SendingAccountId, ReceivingAccountId, Amount);

            if (result == ITransactionsService.ErrorCodes.OK)
            {
                
                return RedirectToPage("/Transactions/SuccessPage");
            }

            
            if (result == ITransactionsService.ErrorCodes.AccountNotFound)
            {
                ModelState.AddModelError(nameof(SendingAccountId), "Sending account not found.");
            }
            else if (result == ITransactionsService.ErrorCodes.DestinationAccountId)
            {
                ModelState.AddModelError(nameof(ReceivingAccountId), "Receiving account not found.");
            }
            else if (result == ITransactionsService.ErrorCodes.BalanceTooLow)
            {
                ModelState.AddModelError(nameof(Amount), "Insufficient balance in the sending account.");
            }
            else if (result == ITransactionsService.ErrorCodes.IncorrectAmount)
            {
                ModelState.AddModelError(nameof(Amount), "Amount must be between 100 and 10,000.");
            }

            return Page();
        }
    }
}

