using DesignPatterns.Decorator.CachedRepoSample.Data.Models;

namespace DesignPatterns.Decorator.CachedRepoSample.Models;

public class IndexViewModel
{
    public IEnumerable<Author> Authors { get; set; }
    public long ElapsedTimeMilliseconds { get; set; }
}
