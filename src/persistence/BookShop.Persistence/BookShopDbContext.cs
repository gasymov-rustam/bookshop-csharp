using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Persistence;

public class BookShopDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Department> Departments { get; set; }

    public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder buider)
        => buider.ApplyConfigurationsFromAssembly(GetType().Assembly);
}