using DesignPatterns.Decorator.CachedRepoSample.Data;
using DesignPatterns.Decorator.CachedRepoSample.Data.Models;
using DesignPatterns.Decorator.CachedRepoSample.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/app-.log",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");;

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(EfRepository<>));
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped(serviceProvider =>
{
    var memoryCache = serviceProvider.GetService<IMemoryCache>();
    var logger = serviceProvider.GetService<ILogger<AuthorRepositoryLoggingDecorator>>();

    var authorRepository = serviceProvider.GetRequiredService<AuthorRepository>();

    IReadOnlyRepository<Author> cachingDecorator = new AuthorRepositoryCachingDecorator(authorRepository, memoryCache!);
    IReadOnlyRepository<Author> loggingDecorator = new AuthorRepositoryLoggingDecorator(cachingDecorator, logger!);

    return loggingDecorator;
});

/*
 * Using Scrutor from nuget for DI registration and decoration
 * 
services.Decorate<IReadOnlyRepository<Author>, AuthorRepositoryCachingDecorator>();

if (Environment.IsProduction() &&
    Convert.ToBoolean(Configuration["EnableLogging"])
{
    services.Decorate<IReadOnlyRepository<Author>, AuthorRepositoryLoggingDecorator>();
}
*/

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();


app.Run();
