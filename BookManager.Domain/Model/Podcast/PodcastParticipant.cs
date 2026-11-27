using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Domain.Model.Podcast
{
    public class PodcastParticipant
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public PodcastRole PodcastRole { get; set; }
    }

    public enum PodcastRole
    {
        Producer = 1,
        Host = 2,
        CoHost = 3,
        Guest = 4,
        Narrator = 5,
        Speaker = 6
    }
}

