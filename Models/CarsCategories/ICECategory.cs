namespace ShopProject.Models.CarsCategories
{
    public enum EngineType { I, V, H, X, W }
    public class ICECategory : Category
    {
        public int EngineCapacity { get; set; }
        public int PistonCount { get; set; }
        public EngineType _EngineType { get; set; }
        public int TankCapacity { get; set; }
        public ICECategory()
        {
            Name = "Классический автомобиль";
            Description = "Автомобиль с двигателем внутреннего сгорания";
        }
    }
}
