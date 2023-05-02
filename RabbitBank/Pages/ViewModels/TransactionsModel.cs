namespace RabbitBank.Pages.ViewModels
{
    public class TransactionsModel
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public int TransactionId { get; set; }
        public string Date { get; set; }
        public string Transaction { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}
