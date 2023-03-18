using System.ComponentModel.DataAnnotations;

namespace ShopProject.Models.CarsCategories
{
    public enum DrivetrainType { AWD, FWD, RWD, FRWD }
    public abstract class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DrivetrainType _DrivetrainType { get; set; }
        public int EngineSpinningMoment { get; set; }
    }
}
