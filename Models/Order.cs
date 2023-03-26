using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public People People { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<Car> Cars { get; set; } = new List<Car>();
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
