using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitBank.Pages.ViewModels;
using RabbitBank.Services;

namespace RabbitBank.Pages.Transactions
{
    public class HistoryModel : PageModel
    {
        private readonly ITransactionsService _transactionsService;

        public HistoryModel(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        public List<TransactionsModel> Transactions { get; set; }

        [BindProperty(SupportsGet = true)]
        public int AccountId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public void OnGet()
        {
            Transactions = _transactionsService.GetTransactionsHistory(AccountId, PageNumber, PageSize);
        }

        public PartialViewResult OnGetMoreTransactions(int accountId, int pageNumber)
        {
            var transactions = _transactionsService.GetTransactionsHistory(accountId, pageNumber, PageSize);
            return Partial("_TransactionsPartial", transactions);
        }
    }
}
