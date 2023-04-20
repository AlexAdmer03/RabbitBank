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
        
    }
}
