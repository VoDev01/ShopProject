using Microsoft.EntityFrameworkCore;
using ShopProject.Data;
using ShopProject.Models.Interfaces;
using System.Linq.Expressions;

namespace ShopProject.Models.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext db;
        public RepositoryBase(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public IEnumerable<T> GetAll() => db.Set<T>();
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression) => db.Set<T>().Where(expression);
        public void Update(T entity) => db.Set<T>().Update(entity);
        public void Create(T entity) => db.Set<T>().Add(entity);
        public void Delete(T entity) => db.Set<T>().Remove(entity);
        public void Save() => db.SaveChanges();
    }
}
