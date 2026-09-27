namespace BookManager.Data.Model
{
    public  class Author
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public string? Image { get; internal set; }
        public List<Book> Books { get; set; }
    }
}
