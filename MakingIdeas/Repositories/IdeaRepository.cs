using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MakingIdeas.Models;

namespace MakingIdeas.Repositories
{
    public class IdeaRepository
    {
        public IEnumerable<Idea> GetNewestIdeas(int amount)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ideas = ctx.Ideas.OrderByDescending(n => n.CreatedDate);

                if (amount > 0)
                {
                    return ideas.Take(amount).ToList();
                }
                return ideas.ToList();
            }
        }

        public IEnumerable<Idea> GetTrandingIdeas(int amount)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ideas = ctx.Ideas.OrderByDescending(n => n.Likes);

                if (amount > 0)
                {
                    return ideas.Take(amount).ToList();
                }
                return ideas.ToList();
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
                    ctx.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
    }
}