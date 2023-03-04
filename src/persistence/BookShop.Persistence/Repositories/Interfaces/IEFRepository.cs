using BookShop.Domain.Entities;
using System.Linq.Expressions;

namespace BookShop.Persistence.Repositories.Interfaces;

public interface IEFRepository<T> where T : BaseEntity
{
    ValueTask<T> GetById(Guid id);
    ValueTask<IEnumerable<T>> GetAll();
    ValueTask<Guid> Add(T entity);
    ValueTask<Guid> Update(T entity);
    ValueTask<Guid> Delete(T entity);
    ValueTask<T> GetByCondition(Expression<Func<T, bool>> item);
}

