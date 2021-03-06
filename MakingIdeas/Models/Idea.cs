﻿using System.Collections;
using System.Collections.Generic;

namespace MakingIdeas.Models
{
    public class Idea : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; }

        public string Project { get; set; }
        public string ThumbnailUrl { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Idea()
        {
            Tags = new List<Tag>();
        }
    }
}