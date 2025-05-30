using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI8.DTOs.Author;
using WebAPI8.Models;
using WebAPI8.Services.Author;

namespace WebAPI8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        #region Author Instance Interface

        private readonly IAuthorService _IauthorService;

        public AuthorController(IAuthorService authorService)
        {
            _IauthorService = authorService;
        } 

        #endregion

        #region Author Methods

        #region [HttpGet]

        [HttpGet("GetAuthors")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAuthors()
        {
            var authors = await _IauthorService.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("GetAuthorById/{authorId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int authorId)
        {
            var author = await _IauthorService.GetAuthorById(authorId);
            return Ok(author);
        }

        [HttpGet("GetAuthorByBookId/{bookId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByBookId(int bookId)
        {
            var author = await _IauthorService.GetAuthorByBookId(bookId);
            return Ok(author);
        }

        #endregion

        #region [HttpPost]

        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(AuthorCreationDTO authorCreationDTO)
        {
            var authors = await _IauthorService.CreateAuthor(authorCreationDTO);
            return Ok(authors);
        }

        #endregion

        #region [HttpPut]

        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> UpdateAuthor(AuthorUpdateDTO authorUpdateDTO)
        {
            var authors = await _IauthorService.UpdateAuthor(authorUpdateDTO);
            return Ok(authors);
        }

        #endregion

        #region [HttpDelete]

        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int authorId)
        {
            var author = await _IauthorService.DeleteAuthor(authorId);
            return Ok(author);
        }

        #endregion

        #endregion
    }
}
