using LibDB.models;
using Microsoft.EntityFrameworkCore;

namespace LibDB.data
{
    public class LibContext : DbContext
    {
        public LibContext(DbContextOptions<LibContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRental> BookRental { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Library");
        }

    }
}
