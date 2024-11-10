using RikaWebShop.Infrastructure.Models;

namespace RikaWebShop.Infrastructure.Interfaces
{
    public interface IBaseRepository<T>
    {
        ResponseResult<T> Create(T entity);
        ResponseResult<T> DeleteOne(Func<T, bool> predicate);
        ResponseResult<List<T>> GetAll();
        ResponseResult<T> GetOne(Func<T, bool> predicate);
        ResponseResult<T> UpdateOne(Func<T, bool> predicate, T updatedEntity);
    }
}