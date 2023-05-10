using RabbitBank.Pages.ViewModels;

namespace RabbitBank.Services
{
    public interface ITransactionsService
    {
        public enum ErrorCodes
        {
            OK,
            BalanceTooLow,
            IncorrectAmount,
            AccountNotFound,
            DestinationAccountId
        }
        List<TransactionsModel> GetTransactionsHistory(int accountIdm, int PageNumber, int PageSize);

        ErrorCodes Withdraw(int accountId, decimal amount);
        ErrorCodes Deposit(int accountId, decimal amount);
        ErrorCodes Transfer(int sendingAccount, int receivingAccount, decimal amount);
        
    }
}
