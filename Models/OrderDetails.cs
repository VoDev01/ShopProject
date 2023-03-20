using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    public class OrderDetails
    {
        public int OrdersID { get; set; }
        public virtual Orders Orders { get; set; }
        public int CarsID { get; set; }
        public virtual Car Cars { get; set; }
        public int Amount { get; set; } = 1;
    }
}
