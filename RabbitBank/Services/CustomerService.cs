using RabbitBank.BankAppData;
using System.Linq;
using System.Collections.Generic;

namespace RabbitBank.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly BankAppDataContext _dbContext;

        public List<Customer> GetCustomers(string searchTerm, string city, int pageNumber, int pageSize)
        {
            IQueryable<Customer> customerQuery = _dbContext.Customers;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                customerQuery = customerQuery.Where(c => c.Givenname.ToLower().Contains(searchTerm) ||
                                                         c.Surname.ToLower().Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(city))
            {
                city = city.ToLower();
                customerQuery = customerQuery.Where(c => c.City.ToLower().Contains(city));
            }

            customerQuery = customerQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return customerQuery.ToList();
        }

        public int GetTotalCustomersCount(string q, string city)
        {
            IQueryable<Customer> customerQuery = _dbContext.Customers;

            if (!string.IsNullOrEmpty(q))
            {
                q = q.ToLower();
                customerQuery = customerQuery.Where(c => c.Givenname.ToLower().Contains(q) ||
                                                         c.Surname.ToLower().Contains(q));
            }

            if (!string.IsNullOrEmpty(city))
            {
                city = city.ToLower();
                customerQuery = customerQuery.Where(c => c.City.ToLower().Contains(city));
            }

            return customerQuery.Count();
        }
    }
}

//----------------------------------------------
//public CustomerService(BankAppDataContext dbContext)
//{
//    _dbContext = dbContext;
//}

//private readonly BankAppDataContext _dbContext;

//public List<Customer> GetCustomers(string q, string city, int pageNumber, int pageSize)
//{
//    IQueryable<Customer> customerQuery = _dbContext.Customers;

//    if (!string.IsNullOrEmpty(q))
//    {
//        q = q.ToLower();
//        customerQuery = customerQuery.Where(c => c.Givenname.ToLower().Contains(q) ||
//                                                 c.Surname.ToLower().Contains(q));
//    }

//    if (!string.IsNullOrEmpty(city))
//    {
//        city = city.ToLower();
//        customerQuery = customerQuery.Where(c => c.City.ToLower().Contains(city));

//    }

//    customerQuery = customerQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);

//    return customerQuery.ToList();
//}

//public Customer GetCustomerById(int customerId)
//{
//    return _dbContext.Customers.Find(customerId);
//}