using System.Threading.Tasks;
using RabbitBank.BankAppData;
using RabbitBank.Pages.ViewModels;

namespace RabbitBank.Services
{
    public interface ICardService
    {
        CustomerModel GetCustomerCard(int customerId);
    }
}