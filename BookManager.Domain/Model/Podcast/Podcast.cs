using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Domain.Model.Podcast
{
    public class Podcast
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string Cover { get; set; }
        public string Duration { get; set; }
        public string RegDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid? PodCastPlayListId { get; set; }
        public PodcastPlaylist? PodCastPlayList { get; set; }
        public IEnumerable<PodcastParticipant> PodcastParticipant { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
