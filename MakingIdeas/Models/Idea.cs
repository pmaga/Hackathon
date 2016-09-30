namespace MakingIdeas.Models
{
    public class Idea : Entity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public int Likes { get; set; }
    }
}