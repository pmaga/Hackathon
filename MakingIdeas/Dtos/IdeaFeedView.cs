using System;

namespace MakingIdeas.Dtos
{
    public class IdeaFeedView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Likes { get; set; }

        public IdeaFeedView(int id, string title, string body, DateTime createdDate, int likes)
        {
            Id = id;
            Title = title;
            Body = body;
            CreatedDate = createdDate;
            Likes = likes;
        }
    }
}