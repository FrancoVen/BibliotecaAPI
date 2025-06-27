using BibliotecaAPI.Entities;
using LibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Autors { get; set; }

        public DbSet<Book> Books { get; set; }

        #region Constructors
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }
        #endregion
    }
}
