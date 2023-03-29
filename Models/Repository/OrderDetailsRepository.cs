using ShopProject.Data;
using ShopProject.Models.Interfaces;

namespace ShopProject.Models.Repository
{
    public class OrderDetailsRepository : RepositoryBase<OrderDetails>, IOrderDetails
    {
        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
