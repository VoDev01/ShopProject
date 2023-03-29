using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    public class OrderDetails
    {
        public int OrdersID { get; set; }
        public Order Orders { get; set; }
        public int CarsID { get; set; }
        public Car Cars { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
