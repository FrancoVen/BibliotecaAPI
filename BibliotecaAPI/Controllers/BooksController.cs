using BibliotecaAPI.Data;
using BibliotecaAPI.Entities;
using LibraryAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
           var books = await _context.Books.ToListAsync();

           return Ok(books);
        }


        [HttpGet("{id:int}")]   
        public async Task<ActionResult<Book>> Get(int id)
        {
            Book? searchedBook = await _context.Books.Include(x=> x.Author).FirstOrDefaultAsync(x => x.Id == id);

            if(searchedBook is null)
            {
                return NotFound("The book searched doesn't exist");
            }
            return Ok(searchedBook);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Book pBook)
        {
            bool author = await _context.Autors.AnyAsync(t => t.Id== pBook.AuthorId);

            if (!author)
            {
                return BadRequest($"The author with ID {pBook.AuthorId} doesn't exist.");
            }


            bool exist = await _context.Books.AnyAsync(x => x.Title == pBook.Title);

            if (exist)
            {
                return Conflict("The entered book already exists.");
            }

            _context.Books.Add(pBook);

            await _context.SaveChangesAsync();  

            return CreatedAtAction(nameof(Get),new {id = pBook.Id}, pBook);
        }


        [HttpPut("{id:int}")]

        public async Task<IActionResult> Put(int id, Book pBook)
        {
            if (id != pBook.Id)
            {
                return BadRequest("The IDs must be equals");
            }

            var exist = await _context.Books.AnyAsync(x=> x.Id == id);

            if (!exist)
            {
                return BadRequest($"No book found with ID {id}.");
            }

            _context.Books.Update(pBook);
            await _context.SaveChangesAsync();

            return NoContent();

        }


        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var searched = await _context.Books.FindAsync(id);

            if (searched is null)
            { 
                return NotFound($"No book found with ID{id}");
            }

            _context.Books.Remove(searched);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        public BooksController(ApplicationDbContext pContext)
        {
            this._context = pContext;
        }
    }
}
