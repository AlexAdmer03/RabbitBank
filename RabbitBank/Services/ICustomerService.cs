using RabbitBank.BankAppData;

namespace RabbitBank.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers(string searchTerm, string city, int pageNumber, int pageSize, string sortColumn, string sortOrder);

        //Customer GetCustomerById(int customerId);
        int GetTotalCustomersCount(string searchTerm, string city);

    }
}
