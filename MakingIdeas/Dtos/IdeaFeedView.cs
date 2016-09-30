using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MakingIdeas.Dtos
{
    public class IdeaFeedView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Likes { get; set; }
        public string ThumbnailUrl { get; set; }
        public IList<string> Tags { get; set; }

        public IdeaFeedView(int id, string title, string body, DateTime createdDate, int likes, string thumbnailUrl, IList<string> tags)
        {
            Id = id;
            Title = title;
            Body = body;
            CreatedDate = createdDate;
            Likes = likes;
            ThumbnailUrl = thumbnailUrl;
            Tags = tags;
        }
    }
}