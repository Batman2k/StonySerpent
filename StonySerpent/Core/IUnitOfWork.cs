using StonySerpent.Core.Repositories;

namespace StonySerpent.Core
{
    public interface IUnitOfWork
    {
        IProductCategoryRepository Categories { get; set; }
        IProductRepository Products { get; set; }
        ICustomerInformationRepository CustomerInformations { get; set; }
        IOrderRepository Orders { get; set; }

        void Finish();
    }
}