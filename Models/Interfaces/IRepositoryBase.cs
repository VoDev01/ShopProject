using System.Linq.Expressions;

namespace ShopProject.Models.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWith(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAllWith(Expression<Func<T, bool>> filter, string children);
        IEnumerable<T> GetAllWith(string children);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetByID(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
