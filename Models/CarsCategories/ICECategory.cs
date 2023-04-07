namespace ShopProject.Models.CarsCategories
{
    public class ICECategory : Category
    {
        public ICECategory()
        {
            Name = "Классический автомобиль";
            Description = "Автомобиль с двигателем внутреннего сгорания";
            CarEngine = 1;
        }
    }
}
