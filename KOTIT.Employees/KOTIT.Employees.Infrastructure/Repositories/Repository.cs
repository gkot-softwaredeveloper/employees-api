using KOTIT.Employees.Domain.Entities;
using KOTIT.Employees.Domain.Repositories;
using KOTIT.Employees.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace KOTIT.Employees.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly BaseContext _context;
    public Repository(BaseContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
}
