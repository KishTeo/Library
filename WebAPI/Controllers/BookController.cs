using LibLogic.Interfaces;
using LibLogic.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
        [Route("/Book/")]
        [ApiController]
        public class BookControler : Controller
        {
            private IBookService _bookService;
            public BookControler(IBookService bookService)
            {
                _bookService = bookService;
            }
            [HttpPost]
             public async Task<ActionResult<BookDTO>> Create(BookDTO item)
            {
                 if (item == null)
                 {
                     return BadRequest();
                 }
                await _bookService.AddBookAsync(item);
                return Ok(item);
            }
            [HttpPut]
            public async Task<ActionResult<BookDTO>> Update(BookDTO item)
            {
                if (item is null)
                {
                    return BadRequest();
                }
                var books = await _bookService.GetAllBooksAsync();
                var book = books.FirstOrDefault(x => x.BookId == item.BookId);
                if (book is null)
                {
                    return NotFound();
                }
                await _bookService.UpdateBookAsync(item);
                return Ok(item);
            }
            [HttpDelete("{id}")]
            public async Task<ActionResult<BookDTO>> Delete(int id)
            {
                var books = await _bookService.GetAllBooksAsync();
                var book = books.FirstOrDefault(x => x.BookId == id);
                if (book is null)
                {
                    return NotFound();
                }
                await _bookService.DeleteBookAsync(id);
                return Ok(book);
            }
            [HttpPut("OffsBook/{id}")]
            public async Task<ActionResult<BookDTO>> OffsBook(int id)
            {
                var books = await _bookService.GetAllBooksAsync();
                var book = books.FirstOrDefault(x => x.BookId == id);
                if (book is null)
                {
                    return NotFound();
                }
                await _bookService.OffsBookAsync(id);
                return Ok(book);
            }
        /*
        [HttpGet("report")]
        public async Task<IActionResult> GetReport()
        {
            var report = await GenerateReport();
            return Ok(report);
        }
        */



        [HttpGet]
            public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
            {
                var books = await _bookService.GetAllBooksAsync();
                return books is not null ? Ok(books) : NoContent();
            }
    }
}
