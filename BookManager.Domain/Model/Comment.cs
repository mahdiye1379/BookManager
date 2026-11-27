namespace BookManager.Domain.Model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommentDescription { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid? ParentCommentID { get; set; }
        public Comment? ParentComment { get; set; }
        public ICollection<Comment>? Replies { get; set; } = new List<Comment>();

        public Guid BookId { get; set; }
        public Book? book { get; set; }

        public Guid PodCastId { get; set; }
        public Podcast? Podcast { get; set; }

    }
}
