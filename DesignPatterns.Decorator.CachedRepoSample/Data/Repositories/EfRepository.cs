using DesignPatterns.Decorator.CachedRepoSample.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Decorator.CachedRepoSample.Data.Repositories;

public class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _dbContext;

    public EfRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public T GetById(int id)
    {
        return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
    }

    public virtual List<T> List()
    {
        return _dbContext.Set<T>().ToList();
    }

    public T Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();

        return entity;
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }
}
