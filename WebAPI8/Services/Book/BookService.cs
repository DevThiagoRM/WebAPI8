using Azure;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using WebAPI8.Data;
using WebAPI8.DTOs.Author;
using WebAPI8.DTOs.Book;
using WebAPI8.Models;

namespace WebAPI8.Services.Book
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _appDbContext;

        public BookService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseModel<List<BookModel>>> CreateBook(BookCreationDTO bookCreationDTO)
        {
            ResponseModel<List<BookModel>> response = new();

            try
            {
                var author = await _appDbContext.Authors
                    .FirstOrDefaultAsync(dbAuthor => dbAuthor.AuthorId == bookCreationDTO.Author.AuthorId);

                if (author == null)
                {
                    response.Message = "Author register not found";
                    return response;
                }

                var book = new BookModel()
                {
                    Title = bookCreationDTO.Title,
                    Author = author
                };

                _appDbContext.Books.Add(book);
                await _appDbContext.SaveChangesAsync();

                response.Data = await _appDbContext.Books.Include(a => a.Author).ToListAsync();
                response.Message = "Book added sucessfully";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId)
        {
            ResponseModel<List<BookModel>> response = new();

            try
            {
                var book = await _appDbContext.Books.FirstOrDefaultAsync(bookDb => bookDb.BookId == bookId);

                if (book == null)
                {
                    response.Message = "Book not found.";
                    return response;
                }

                _appDbContext.Remove(book);
                await _appDbContext.SaveChangesAsync();

                response.Data = await _appDbContext.Books.ToListAsync();
                response.Message = "Book deleted.";

                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<BookModel>> GetBookById(int bookId)
        {
            ResponseModel<BookModel> response = new();

            try
            {
                var book = await _appDbContext.Books.FirstOrDefaultAsync(bookDb => bookDb.BookId == bookId);

                if (book == null)
                {
                    response.Message = "Book Id not found";
                    return response;
                }

                response.Message = "Book found";
                response.Data = book;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> GetBooks()
        {
            ResponseModel<List<BookModel>> response = new();

            try
            {
                var books = await _appDbContext.Books.ToListAsync();

                if (books == null)
                {
                    response.Message = "Books not found.";
                    return response;
                }

                response.Data = books;
                response.Message = "All books are collected";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> GetBookByAuthorId(int authorId)
        {
            ResponseModel<List<BookModel>> response = new();

            try
            {
                var book = await _appDbContext.Books
                    .Include(a => a.Author)
                    .Where(dbBook => dbBook.Author.AuthorId == authorId)
                    .ToListAsync();

                if (book == null)
                {
                    response.Message = "Book not found.";
                    return response;
                }

                response.Data = book;
                response.Message = "Book located";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> UpdateBook(BookUpdateDTO bookUpdateDTO)
        {
            ResponseModel<List<BookModel>> response = new();

            try
            {
                var book = await _appDbContext.Books
                     .Include(a => a.Author)
                     .FirstOrDefaultAsync(dbBook => dbBook.BookId == bookUpdateDTO.BookId);

                var author = await _appDbContext.Authors
                    .FirstOrDefaultAsync(dbAuthor => dbAuthor.AuthorId == bookUpdateDTO.Author.AuthorId);

                if (book == null)
                {
                    response.Message = "Register author not found.";
                    return response;
                }

                if ( author == null)
                {
                    response.Message = "Register book not found.";
                    return response;
                }

                book.Title = bookUpdateDTO.Title;
                book.Author = author;

                _appDbContext.Update(book);
                await _appDbContext.SaveChangesAsync();

                response.Data = await _appDbContext.Books.ToListAsync();

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
