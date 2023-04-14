using RabbitBank.BankAppData;

namespace RabbitBank.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers(string searchTerm, string city, int pageNumber, int pageSize);

        //Customer GetCustomerById(int customerId);
        int GetTotalCustomersCount(string searchTerm, string city);

    }
}
