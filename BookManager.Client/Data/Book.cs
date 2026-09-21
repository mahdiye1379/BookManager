namespace BookManager.Client.Data
{
    public class Book
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string RegDate { get; set; }
        public int TotalPage { get; set; }   
        public int CurrentReadingPage { get; set; }
        public string Cover { get; set; } 
        public string Summery { get; set; }
        public string FilePath { get; set; }
        public DateTime LastUpdate { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
