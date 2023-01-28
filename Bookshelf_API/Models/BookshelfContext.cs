using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Bookshelf_API.Models
{
    public class BookshelfContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public BookshelfContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Author).IsRequired();
                entity.Property(e => e.Tags).HasConversion(
                    x => JsonSerializer.Serialize(x, (JsonSerializerOptions)null),
                    x => JsonSerializer.Deserialize<string[]>(x, (JsonSerializerOptions)null)
                );
            });
        }
    }
}
