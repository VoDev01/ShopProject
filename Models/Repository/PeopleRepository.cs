using ShopProject.Data;
using ShopProject.Models.Interfaces;

namespace ShopProject.Models.Repository
{
    public class PeopleRepository : RepositoryBase<People>, IPeople
    {
        public PeopleRepository(ApplicationDbContext db) : base(db) { }
    }
}
