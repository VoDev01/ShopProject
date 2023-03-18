namespace ShopProject.Models.CarsCategories
{
    public class ElectricCategory : Category
    {
        public int BatteryCapacity { get; set; }
        public int BatteryDrainage { get; set; }
        public ElectricCategory()
        {
            Name = "Электрический автомобиль";
            Description = "Автомобиль с электрическим двигателем";
        }
    }
}
