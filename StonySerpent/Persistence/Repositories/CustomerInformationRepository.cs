using System.Linq;
using StonySerpent.Core.Models;
using StonySerpent.Core.Repositories;

namespace StonySerpent.Persistence.Repositories
{
    public class CustomerInformationRepository : ICustomerInformationRepository
    {
        private readonly IApplicationDbContext _context;

        public CustomerInformationRepository(IApplicationDbContext context)
        {
            _context = context;
        }


        public CustomerInformation GetInfoById(string userId)
        {
            return _context
                .CustomerInformations
                .FirstOrDefault(ci => ci.UserId == userId);
        }

        public void Add(CustomerInformation customerInformation)
        {
            _context
                .CustomerInformations
                .Add(customerInformation);
        }
    }
}