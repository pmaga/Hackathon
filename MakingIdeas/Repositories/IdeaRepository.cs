using System.Collections;
using System.Collections.Generic;
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
                return ctx.Ideas.OrderByDescending(n => n.CreatedDate).Take(amount).ToList();
            }
        }

        public IEnumerable<Idea> GetTrandingIdeas(int amount)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Ideas.OrderByDescending(n => n.Likes).Take(amount).ToList();
            }
        }
    }
}