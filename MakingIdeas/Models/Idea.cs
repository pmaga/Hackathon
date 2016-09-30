using System.Collections;
using System.Collections.Generic;

namespace MakingIdeas.Models
{
    public class Idea : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; }

        public string Project { get; set; }
        public IList<string> Tags { get; set; }

        public Idea()
        {
            Tags = new List<string>();
        }
    }
}