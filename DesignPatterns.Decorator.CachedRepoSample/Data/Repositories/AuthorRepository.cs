using DesignPatterns.Decorator.CachedRepoSample.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Decorator.CachedRepoSample.Data.Repositories;

public class AuthorRepository : EfRepository<Author>
{
    public AuthorRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override List<Author> List()
    {
        return _dbContext.Authors.Include(u => u.Resources).ToList();
    }
}
