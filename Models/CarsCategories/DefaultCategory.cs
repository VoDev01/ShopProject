using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopProject.Models.CarsCategories
{
    public class DefaultCategory : Category
    {
        public DefaultCategory()
        {
            Name = "Default";
            Description = "Default";
            CarEngine = 0;
        }
    }
}
