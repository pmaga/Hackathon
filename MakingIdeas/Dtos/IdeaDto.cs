using System.Collections.Generic;

namespace MakingIdeas.Dtos
{
    public class IdeaDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; }

        public string Project { get; set; }
        public string ThumbnailUrl { get; set; }
        public IList<string> Tags { get; set; }

        public IdeaDto()
        {
            Tags = new List<string>();
        }
    }
}