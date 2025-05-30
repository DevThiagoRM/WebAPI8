namespace WebAPI8.DTOs.Author
{
    public class AuthorUpdateDTO
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
    }
}
