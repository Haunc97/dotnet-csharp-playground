using DesignPatterns.Decorator.CachedRepoSample.Data.Models;

namespace DesignPatterns.Decorator.CachedRepoSample.Data.Repositories;

public class AuthorRepositoryLoggingDecorator : IReadOnlyRepository<Author>
{
    private readonly IReadOnlyRepository<Author> _authorRepository;
    private readonly ILogger<AuthorRepositoryLoggingDecorator> _logger;

    public AuthorRepositoryLoggingDecorator(
        IReadOnlyRepository<Author> authorRepository,
        ILogger<AuthorRepositoryLoggingDecorator> logger)
    {
        _authorRepository = authorRepository;
        _logger = logger;
    }

    public Author GetById(int id)
    {
        try
        {
            var author = _authorRepository.GetById(id);

            if (author is null)
            {
                _logger.LogWarning(
                    "Author not found for Id = {AuthorId}", id);
            }
            else
            {
                _logger.LogInformation(
                    "Successfully retrieved Author {AuthorId} - {AuthorName}",
                    author.Id, author.Name);
            }

            return author;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Error occurred while fetching Author Id = {AuthorId}",
                id);

            throw;
        }
    }

    public List<Author> List()
    {
        _logger.LogInformation("Fetching Author list");

        try
        {
            var authors = _authorRepository.List();

            _logger.LogInformation(
                "Retrieved {AuthorCount} authors",
                authors.Count);

            return authors;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Error occurred while fetching Author list");

            throw;
        }
    }
}
