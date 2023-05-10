using RabbitBank.BankAppData;
using RabbitBank.Pages.ViewModels;


namespace RabbitBank.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly BankAppDataContext _dbContext;

        public TransactionsService(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TransactionsModel> GetTransactionsHistory(int accountId, int pageNumber, int pageSize)
        {
            var query = _dbContext.Transactions
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.Date)
                .OrderByDescending(t => t.TransactionId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new TransactionsModel()
                {
                    AccountId = accountId,
                    TransactionId = t.TransactionId,
                    Date = t.Date.ToShortDateString(),
                    Transaction = t.Operation,
                    Amount = t.Amount,
                    Balance = t.Balance
                });

            return query.ToList();
        }
        public ITransactionsService.ErrorCodes Withdraw(int accountId, decimal amount)
        {
            if (amount < 100 || amount > 10000)
            {
                return ITransactionsService.ErrorCodes.IncorrectAmount;
            }

            var account = _dbContext.Accounts.First(a => a.AccountId == accountId);
            if (account == null)
            {
                return ITransactionsService.ErrorCodes.AccountNotFound;
            }

            if (account.Balance < amount)
            {
                return ITransactionsService.ErrorCodes.BalanceTooLow;
            }

            account.Balance -= amount;
            var transaction = new Transaction
            {
                AccountId = accountId,
                Date = DateTime.Now,
                Operation = "Withdraw",
                Type = "Credit",
                Amount = amount * -1,
                Balance = account.Balance
            };
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return ITransactionsService.ErrorCodes.OK;
        }

        public ITransactionsService.ErrorCodes Deposit(int accountId, decimal amount)
        {
            if (amount < 100 || amount > 10000)
            {
                return ITransactionsService.ErrorCodes.IncorrectAmount;
            }

            var account = _dbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account == null)
            {
                return ITransactionsService.ErrorCodes.AccountNotFound;
            }

            account.Balance += amount;
            var transaction = new Transaction
            {
                AccountId = accountId,
                Date = DateTime.Now,
                Operation = "Deposit",
                Type = "Debit",
                Amount = amount,
                Balance = account.Balance
            };
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return ITransactionsService.ErrorCodes.OK;
        }
        public ITransactionsService.ErrorCodes Transfer(int sendingAccount, int receivingAccount, decimal amount)
        {
            if (amount < 100 || amount > 10000)
            {
                return ITransactionsService.ErrorCodes.IncorrectAmount;
            }

            var sourceAccount = _dbContext.Accounts.FirstOrDefault(a => a.AccountId == sendingAccount);
            var destinationAccount = _dbContext.Accounts.FirstOrDefault(a => a.AccountId == receivingAccount);

            if (sourceAccount == null)
            {
                return ITransactionsService.ErrorCodes.AccountNotFound;
            }

            if (destinationAccount == null)
            {
                return ITransactionsService.ErrorCodes.DestinationAccountId;
            }

            if (sourceAccount.Balance < amount)
            {
                return ITransactionsService.ErrorCodes.BalanceTooLow;
            }

            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            var transactionWithdraw = new Transaction
            {
                AccountId = sendingAccount,
                Date = DateTime.Now,
                Operation = "Transfer",
                Type = "Credit",
                Amount = amount * -1,
                Balance = sourceAccount.Balance
            };

            var transactionDeposit = new Transaction
            {
                AccountId = receivingAccount,
                Date = DateTime.Now,
                Operation = "Transfer",
                Type = "Debit",
                Amount = amount,
                Balance = destinationAccount.Balance
            };

            _dbContext.Transactions.Add(transactionWithdraw);
            _dbContext.Transactions.Add(transactionDeposit);
            _dbContext.SaveChanges();

            return ITransactionsService.ErrorCodes.OK;
        }
    }
}
