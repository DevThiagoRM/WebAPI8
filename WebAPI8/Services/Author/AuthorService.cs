using Microsoft.EntityFrameworkCore;
using WebAPI8.Data;
using WebAPI8.DTOs.Author;
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

        public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreationDTO authorCreationDTO)
        {
            ResponseModel<List<AuthorModel>> response = new();

            try
            {
                var author = new AuthorModel()
                {
                    Name = authorCreationDTO.Name,
                    LastName = authorCreationDTO.LastName
                };

                _appDbContext.Add(author);
                await _appDbContext.SaveChangesAsync();

                response.Data = await _appDbContext.Authors.ToListAsync();
                response.Message = "Author create sucessfully.";

                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId)
        {
            ResponseModel<List<AuthorModel>> response = new();

            try
            {
                var author = await _appDbContext.Authors.FirstOrDefaultAsync(authorDb => authorDb.AuthorId == authorId);

                if (author == null)
                {
                    response.Message = "Author not found.";
                    return response;
                }

                _appDbContext.Remove(author);
                await _appDbContext.SaveChangesAsync();

                response.Data = await _appDbContext.Authors.ToListAsync();
                response.Message = "Author deleted sucessfully";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
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

        public async Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(AuthorUpdateDTO authorUpdateDTO)
        {
            ResponseModel<List<AuthorModel>> response = new();

            try
            {
                var author = await _appDbContext.Authors.FirstOrDefaultAsync(authorDb => authorDb.AuthorId == authorUpdateDTO.AuthorId);

                if (author == null)
                {
                    response.Message = "Author not found.";
                    return response;
                }

                author.Name = authorUpdateDTO.Name;
                author.LastName = authorUpdateDTO.LastName;

                _appDbContext.Update(author);
                await _appDbContext.SaveChangesAsync();

                response.Data = await _appDbContext.Authors.ToListAsync();
                response.Message = "Author update sucessfully";

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
