using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MakingIdeas.Infrastructure;
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

                var urlWithAccessToken = "https://hooks.slack.com/services/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";
                var client = new SlackClient(urlWithAccessToken);

                client.PostMessage(username: "incoming-webhook",
                    text: "A test message from Making Ideas",
                    channel: "#test-your-stuff-here");
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