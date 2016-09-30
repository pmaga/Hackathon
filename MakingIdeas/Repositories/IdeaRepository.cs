using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MakingIdeas.Dtos;
using MakingIdeas.Models;

namespace MakingIdeas.Repositories
{
    public class IdeaRepository
    {
        public IEnumerable<IdeaFeedView> GetNewestIdeas(int amount)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ideas = ctx.Ideas.Include("Tags").OrderByDescending(n => n.CreatedDate).ToList();

                if (amount > 0)
                {
                    return
                        ideas.Take(amount)
                            .Select( n => new IdeaFeedView(n.Id, n.Title, n.Body, n.CreatedDate, n.Likes, n.ThumbnailUrl, n.Tags.Select(t => t.Name).ToList()));
                }
                return ideas.Select(n => new IdeaFeedView(n.Id, n.Title, n.Body, n.CreatedDate, n.Likes, n.ThumbnailUrl, n.Tags.Select(t => t.Name).ToList()));
            }
        }

        public IEnumerable<IdeaFeedView> GetTrandingIdeas(int amount)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ideas = ctx.Ideas.Include("Tags").OrderByDescending(n => n.Likes).ToList();

                if (amount > 0)
                {
                    return ideas.Select(n => new IdeaFeedView(n.Id, n.Title, n.Body, n.CreatedDate, n.Likes, n.ThumbnailUrl, n.Tags.Select(t => t.Name).ToList())).Take(amount).ToList();
                }
                return ideas.Select(n => new IdeaFeedView(n.Id, n.Title, n.Body, n.CreatedDate, n.Likes, n.ThumbnailUrl, n.Tags.Select(t => t.Name).ToList())).ToList();
            }
        }

        public bool AddLike(int ideaId)
        {
            var result = false;
            using (var ctx = new ApplicationDbContext())
            {
                var idea = ctx.Ideas.FirstOrDefault(n => n.Id == ideaId);

                if (idea != null)
                {
                    idea.Likes++;
                    ctx.Entry(idea).State = EntityState.Modified;
                    result = ctx.SaveChanges() > 0;
                }
            }

            return result;
        }

        public bool Create(Idea idea)
        {
            bool result;

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ideas.Add(idea);
                result = ctx.SaveChanges() > 0;
            }

            return result;
        }

        public Idea Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Ideas.FirstOrDefault(n => n.Id == id);
            }
        }
    }
}