using System.ComponentModel.DataAnnotations;
using ShopProject.Models.CarsCategories;

namespace ShopProject.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }
        [Required]
        [StringLength(250)]
        public string Image { get; set; }
        [Required]
        public int Price { get; set; } = 0;
        public bool IsFavorite { get; set; }
        public bool IsAvailable { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
