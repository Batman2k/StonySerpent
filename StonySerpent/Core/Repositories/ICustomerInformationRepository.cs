using StonySerpent.Core.Models;

namespace StonySerpent.Core.Repositories
{
    public interface ICustomerInformationRepository
    {
        CustomerInformation GetInfoById(string userId);
        void Add(CustomerInformation customerInformation);
    }
}