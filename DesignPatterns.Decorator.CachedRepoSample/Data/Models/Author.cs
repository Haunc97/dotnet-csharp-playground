namespace DesignPatterns.Decorator.CachedRepoSample.Data.Models;

public class Author : BaseEntity
{
    public string? Name { get; set; }
    public string? UserId { get; set; }
    public List<Resource> Resources { get; set; }
}
