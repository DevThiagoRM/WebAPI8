using WebAPI8.DTOs.Author;
using WebAPI8.Models;

namespace WebAPI8.Services.Author
{
    public interface IAuthorService
    {
        Task<ResponseModel<List<AuthorModel>>> GetAuthors();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId);
        Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId);
        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreationDTO authorCreationDTO);
        Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(AuthorUpdateDTO authorUpdateDTO);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId);
    }
}
