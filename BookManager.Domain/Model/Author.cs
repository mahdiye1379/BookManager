namespace BookManager.Domain.Model
{

    public class Author
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public string? Image { get; set; }

        public List<Book> Books { get; set; } = new();
    }

}
