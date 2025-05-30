using WebAPI8.DTOs.Association;
using WebAPI8.Models;

namespace WebAPI8.DTOs.Book
{
    public class BookCreationDTO
    {
        public required string Title { get; set; }
        public required AuthorAssocioation Author { get; set; }
    }
}
