
using FormulaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Core.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected ApiDbContext _context;
    internal DbSet<T> _dbset;
    protected readonly ILogger _logger;

    public GenericRepository(
        ApiDbContext context,
        ILogger logger)
    {
        _context = context;
        _logger = logger;
        this._dbset = _context.Set<T>();
    }
    public Task<bool> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
