using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI8.Models;
using WebAPI8.Services.Author;

namespace WebAPI8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        // Instancia a interface

        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAuthors")] // Endpoint
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAuthors()
        {
            var authors = await _authorService.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("GetAuthorById/{authorId}")] // Endpoint
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int authorId)
        {
            var author = await _authorService.GetAuthorById(authorId);
            return Ok(author);
        }

        [HttpGet("GetAuthorByBookId/{bookId}")] // Endpoint
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByBookId(int bookId)
        {
            var author = await _authorService.GetAuthorByBookId(bookId);
            return Ok(author);
        }

    }
}
