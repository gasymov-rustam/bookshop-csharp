using BookShop.Domain.Entities;
using BookShop.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Persistence.Repositories.Implementations;
public sealed class EFRepository<T> : IEFRepository<T> where T : BaseEntity
{
    private readonly BookShopDbContext _context;
    public EFRepository(BookShopDbContext context) { _context = context; }
    public async ValueTask<Guid> Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async ValueTask<Guid> Delete(T entity)
    {
        var item = await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == entity.Id);

        if (item is null)
        {
            return Guid.Empty;
        }

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async ValueTask<IEnumerable<T>> GetAll() => await _context.Set<T>().AsNoTracking().ToListAsync();

    public async ValueTask<T> GetByCondition(Expression<Func<T, bool>> item)
    {
        return await _context.Set<T>().Where(item).FirstOrDefaultAsync();
    }

    public async ValueTask<T> GetById(Guid id)
    {
        var item = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        return item;
    }

    public async ValueTask<Guid> Update(T entity)
    {
        var item = await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == entity.Id);

        if (item is null)
        {
            return Guid.Empty;
        }

        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }
}
