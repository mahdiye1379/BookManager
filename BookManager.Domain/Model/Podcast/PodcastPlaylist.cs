namespace BookManager.Domain.Model.Podcast
{
    public class PodcastPlaylist
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Podcast> Podcasts { get; set; }
    }
}
