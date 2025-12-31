using DesignPatterns.Decorator.CachedRepoSample.Data;
using DesignPatterns.Decorator.CachedRepoSample.Data.Models;
using DesignPatterns.Decorator.CachedRepoSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesignPatterns.Decorator.CachedRepoSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadOnlyRepository<Author> _authorRepository;

        public HomeController(IReadOnlyRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IActionResult Index()
        {
            var sw = Stopwatch.StartNew();

            var authors = _authorRepository.List();

            sw.Stop();

            var model = new IndexViewModel
            {
                Authors = authors,
                ElapsedTimeMilliseconds = sw.ElapsedMilliseconds
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
