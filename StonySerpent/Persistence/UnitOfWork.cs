using StonySerpent.Core;
using StonySerpent.Core.Repositories;
using StonySerpent.Persistence.Repositories;

namespace StonySerpent.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Categories = new ProductCategoryRepository(context);
            Products = new ProductRepository(context);
            CustomerInformations = new CustomerInformationRepository(context);
            Orders = new OrderRepository(context);
        }

        public IProductRepository Products { get; set; }
        public ICustomerInformationRepository CustomerInformations { get; set; }
        public IProductCategoryRepository Categories { get; set; }
        public IOrderRepository Orders { get; set; }


        public void Finish()
        {
            _context.SaveChanges();
        }
    }
}