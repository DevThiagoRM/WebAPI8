using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI8.DTOs.Author;
using WebAPI8.DTOs.Book;
using WebAPI8.Models;
using WebAPI8.Services.Author;
using WebAPI8.Services.Book;

namespace WebAPI8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region Book Instance Interface

        private readonly IBookService _IbookService;

        public BookController(IBookService bookService)
        {
            _IbookService = bookService;
        }

        #endregion

        #region Book Methods

        #region [HttpGet]

        [HttpGet("GetBooks")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBooks()
        {
            var books = await _IbookService.GetBooks();
            return Ok(books);
        }

        [HttpGet("GetBookById/{bookId}")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBookById(int bookId)
        {
            var books = await _IbookService.GetBookById(bookId);
            return Ok(books);
        }

        [HttpGet("GetBookByAuthorId/{authorId}")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBookByAuthorId(int authorId)
        {
            var books = await _IbookService.GetBookByAuthorId(authorId);
            return Ok(books);
        }

        #endregion

        #region [HttpPost]

        [HttpPost("CreateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(BookCreationDTO bookCreationDTO)
        {
            var books = await _IbookService.CreateBook(bookCreationDTO);
            return Ok(books);
        }

        #endregion

        #region [HttpPut]

        [HttpPut("UpdateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> UpdateBook(BookUpdateDTO bookUpdateDTO)
        {
            var books = await _IbookService.UpdateBook(bookUpdateDTO);
            return Ok(books);
        }

        #endregion

        #region [HttpDelete/{bookId}]

        [HttpDelete("DeleteBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int bookId)
        {
            var books = await _IbookService.DeleteBook(bookId);
            return Ok(books);
        }

        #endregion

        #endregion
    }
}
