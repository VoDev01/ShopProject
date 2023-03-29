using ShopProject.Data;
using ShopProject.Models.Interfaces;

namespace ShopProject.Models.Repository
{
    public class OrdersRepository : RepositoryBase<Order>, IAllOrders
    {
        public OrdersRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
