using BibliotecaAPI.Data;
using BibliotecaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
          return await _context.Autors.ToListAsync();
        }

        [HttpGet("{Id:int}")] //api/authors/Id

        public async Task<ActionResult<Author>> Get(int Id)
        {
            var author = await _context.Autors.FindAsync(Id);

            if (author == null) 
            {
                return NotFound();
            }

            return author;
        }





        [HttpPost]
        public async Task<IActionResult> Post(Author pAuthor)
        {
            _context.Autors.Add(pAuthor);   
            await _context.SaveChangesAsync();  
            return Ok();
        }


        [HttpPut("{Id:int}")]
        public async Task<IActionResult> Put(int Id, Author pAuthor)
        {
            if (Id != pAuthor.Id)
            {
                return BadRequest("Ids must be matched");
            }

            _context.Autors.Update(pAuthor);

            await _context.SaveChangesAsync();

            return Ok();    
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var AuthorWanted = await _context.Autors.FindAsync(Id);

            if(AuthorWanted == null)
            {
                return NotFound("The author you want to delete was not found");
            }
            _context.Autors.Remove(AuthorWanted);
            await _context.SaveChangesAsync();

            return Ok("Author deleted successfully");
        }



        #region Builders
        public AuthorsController(ApplicationDbContext pContext)
        {
            this._context = pContext;
        }
        #endregion

    }
}
