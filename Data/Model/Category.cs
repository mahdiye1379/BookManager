namespace BookManager.Model
{
    public class Category
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}

