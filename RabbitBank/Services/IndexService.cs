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
            var countriesList = new List<string>() { "Sweden, Norway, Denmark, Finland" };
            var countryList = new List<CountriesModel>();

            foreach (var country in countriesList)
            {
                var countries = _dbContext.Customers
                    .Where(C => C.Country == country)
                    .Join(_dbContext.Accounts, C => C.CustomerId, A => A.AccountId,
                        (C, A) => new { Customer = C, Account = A })
                    .GroupBy(CA => CA.Customer.Country)
                    .Select(group => new CountriesModel
                    {
                        Country = group.Key,
                        TotalAccounts = group.Count(),
                        TotalBalance = group.Sum(CA => CA.Account.Balance),
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
