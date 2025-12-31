using DesignPatterns.Decorator.CachedRepoSample.Data.Models;

namespace DesignPatterns.Decorator.CachedRepoSample.Data;

public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
{
    T Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
