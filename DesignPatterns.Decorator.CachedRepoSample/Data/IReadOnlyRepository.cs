using DesignPatterns.Decorator.CachedRepoSample.Data.Models;

namespace DesignPatterns.Decorator.CachedRepoSample.Data;

public interface IReadOnlyRepository<T> where T : BaseEntity
{
    T GetById(int id);
    List<T> List();
}
