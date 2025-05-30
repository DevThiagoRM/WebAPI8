using WebAPI8.DTOs.Author;
using WebAPI8.DTOs.Book;
using WebAPI8.Models;

namespace WebAPI8.Services.Book
{
    public interface IBookService
    {
        Task<ResponseModel<List<BookModel>>> GetBooks();
        Task<ResponseModel<BookModel>> GetBookById(int bookId);
        Task<ResponseModel<List<BookModel>>> GetBookByAuthorId(int authorId);
        Task<ResponseModel<List<BookModel>>> CreateBook(BookCreationDTO bookCreationDTO);
        Task<ResponseModel<List<BookModel>>> UpdateBook(BookUpdateDTO bookUpdateDTO);
        Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId);
    }
}
