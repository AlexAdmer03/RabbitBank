using Microsoft.EntityFrameworkCore;
using RabbitBank.BankAppData;
using RabbitBank.Data;
using RabbitBank.Pages.ViewModels;

namespace RabbitBank.Services
{
    public class CardService : ICardService
    {
        private readonly BankAppDataContext _dbContext;

        public CardService(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CustomerModel GetCustomerCard(int customerId)
        {

            var customerCard = _dbContext.Customers
                .Where(c => c.CustomerId == customerId)
                .Join(_dbContext.Dispositions, c => c.CustomerId, d => d.CustomerId,
                    (c, d) => new { Customer = c, AccountId = d.AccountId })
                .Join(_dbContext.Accounts, cd => cd.AccountId, a => a.AccountId,
                    (cd, a) => new { Customer = cd.Customer, Account = a })
                .Select(ca => new CustomerModel()
                {
                    CustomerId = ca.Customer.CustomerId,
                    Gender = ca.Customer.Gender,
                    Givenname = ca.Customer.Givenname,
                    Surname = ca.Customer.Surname,
                    Streetaddress = ca.Customer.Streetaddress,
                    City = ca.Customer.City,
                    Country = ca.Customer.Country,
                    Birthday = (DateTime)ca.Customer.Birthday,
                    Balance = ca.Account.Balance,
                    TelephoneNumber = ca.Customer.Telephonenumber,
                    Email = ca.Customer.Emailaddress,
                    AccountId = ca.Account.AccountId
                })
                .FirstOrDefault();

            return customerCard;
        }
    }
}
