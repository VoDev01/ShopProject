using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public People People { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
