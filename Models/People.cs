using System.ComponentModel.DataAnnotations;

namespace ShopProject.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Range(0,20)]
        public string? Surname { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9_\.-]+\@[\da-z-]+\.[a-z]{2,5}\s")]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        [RegularExpression(@"^[0-9()-]\s")]
        public string PhoneNum { get; set; }
        [Required]
        [StringLength(75)]
        public string Adress { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
