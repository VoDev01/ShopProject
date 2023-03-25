using System.ComponentModel.DataAnnotations;

namespace ShopProject.Models.CarsCategories
{
    public abstract class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
