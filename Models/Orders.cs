using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public ICollection<People> People { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
