using Microsoft.EntityFrameworkCore;
using WebAPI8.Data;
using WebAPI8.Models;

namespace WebAPI8.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _appDbContext;

        public AuthorService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<ResponseModel<List<AuthorModel>>> CreateAuthor()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId)
        {
            ResponseModel<AuthorModel> response = new();

            try
            {
                var book = await _appDbContext.Books
                    .Include(a => a.Author)
                    .FirstOrDefaultAsync(dbBook => dbBook.BookId == bookId);

                if (book == null)
                {
                    response.Message = "Author not found.";
                    return response;
                }

                response.Data = book.Author;
                response.Message = "Author retrieved successfully.";

                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId)
        {
            ResponseModel<AuthorModel> response = new();

            try
            {
                var author = await _appDbContext.Authors.FirstOrDefaultAsync(dbAuthor => dbAuthor.AuthorId == authorId);

                if (author == null)
                {
                    response.Message = "Author not found.";

                    return response;
                }

                response.Data = author;
                response.Message = "Author retrieved successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> GetAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ();

            try
            {
                var authors = await _appDbContext.Authors.ToListAsync();

                response.Data = authors;
                response.Message = "All authors are collected";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }
    }
}
