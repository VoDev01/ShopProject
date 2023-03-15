﻿using System.ComponentModel.DataAnnotations;

namespace ShopProject.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 500)]
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; } = 0;
        public bool IsFavorite { get; set; }
        public bool IsAvailable { get; set; }
        public Category Category { get; set; }
    }
}