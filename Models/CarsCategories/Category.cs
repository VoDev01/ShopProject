using System.ComponentModel.DataAnnotations;

namespace ShopProject.Models.CarsCategories
{
    public abstract class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        [Required]
        [Range(1, 2, ErrorMessage = "Данной категории машин не существует")]
        public int CarEngine { get; set; }
    }
}
