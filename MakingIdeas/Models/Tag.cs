namespace MakingIdeas.Models
{
    public class Tag : Entity
    {
        public int IdeaId { get; set; }
        public virtual Idea Idea { get; set; }

        public string Name { get; set; }
    }
}