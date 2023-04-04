using System.Data.Common;
using RabbitBank.BankAppData;
using RabbitBank.Models;

namespace RabbitBank.Services
{
    public class IndexService : IindexService
    {
        public IndexService(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly BankAppDataContext _dbContext;

        public List<CountriesModel> GetCountriesData()
        {
            var countriesList = new List<string>() { "Sweden", "Norway", "Denmark", "Finland" };
            var countryList = new List<CountriesModel>();

            foreach (var country in countriesList)
            {
                var countries = _dbContext.Customers
                    .Where(c => c.Country == country)
                    .Join(_dbContext.Dispositions, c => c.CustomerId, d => d.CustomerId,
                        (c, d) => new { Customer = c, AccountId = d.AccountId })
                    .Join(_dbContext.Accounts, cd => cd.AccountId, a => a.AccountId,
                        (cd, a) => new { Customer = cd.Customer, Account = a })
                    .GroupBy(ca => ca.Customer.Country)
                    .Select(group => new CountriesModel
                    {
                        Country = group.Key,
                        TotalAccounts = group.Count(),
                        TotalBalance = group.Sum(ca => ca.Account.Balance),
                    })
                    .FirstOrDefault();

                if (countries != null)
                {
                    countryList.Add(countries);
                }
            }

            return countryList;
        }
    }
}