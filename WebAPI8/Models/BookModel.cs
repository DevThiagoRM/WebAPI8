using System.ComponentModel.DataAnnotations;

namespace WebAPI8.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public AuthorModel Author { get; set; }
    }
}
