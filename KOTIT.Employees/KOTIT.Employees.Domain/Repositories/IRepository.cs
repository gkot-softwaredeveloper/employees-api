using KOTIT.Employees.Domain.Entities;

namespace KOTIT.Employees.Domain.Repositories;

public interface IRepository<T> where T : class, IEntity
{
    public Task<IEnumerable<T>> GetAllAsync();
}
