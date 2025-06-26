using System.ComponentModel.DataAnnotations;
using LibraryAPI.Entities;

namespace BibliotecaAPI.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();    
    }
}
