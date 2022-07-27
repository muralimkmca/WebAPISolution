using Core6MongoDb.Model;
using Core6MongoDb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core6MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly BooksService booksService;

        public BooksController(BooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet]
        public async Task<List<Books>> Get() =>
              await booksService.GetAsync();


        [HttpPost]
        public async Task<IActionResult> Post(Books newBook)
        {
            await booksService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }
    }
}
