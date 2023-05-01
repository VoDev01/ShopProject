using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Длина имени не должна превышать 20 символов")]
        [MinLength(2, ErrorMessage = "Длина имени не менее 2 символов")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [MaxLength(30, ErrorMessage = "Длина фамилии не должна превышать 30 символов")]
        [MinLength(5, ErrorMessage = "Длина фамилии не менее 5 символов")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Введите электронную почту")]
        [MaxLength(50, ErrorMessage = "Длина email не должна превышать 50 символов")]
        [MinLength(10, ErrorMessage = "Длина email не менее 10 символов")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Не соотвествует адресу электронной почты")]
        [Remote(action: "CheckEmail", controller: "Order", ErrorMessage = "Данный email уже кем-то используется")]
        public string Email { get; set; }
        [MaxLength(18, ErrorMessage = "Длина номера телефона не должна превышать 18 символов")]
        [MinLength(10, ErrorMessage = "Длина номера телефона не менее 10 символов")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Не соответсвует номеру телефона")]
        public string? PhoneNum { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
