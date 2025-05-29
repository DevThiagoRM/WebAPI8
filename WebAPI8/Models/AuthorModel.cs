using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI8.Models
{
    public class AuthorModel
    {
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public ICollection<BookModel> Books { get; set; }
    }
}
