using System.Collections.Generic;

namespace MakingIdeas.Models
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var ideas = new List<Idea>
            {
                new Idea {Title = "Idea 1", Body = "Idea 1 body"},
                new Idea {Title = "Idea 2", Body = "Idea 2 body"},
                new Idea {Title = "Idea 3", Body = "Idea 3 body"},
                new Idea {Title = "Idea 4", Body = "Idea 4 body"},
                new Idea {Title = "Idea 5", Body = "Idea 5 body"}
            };

            context.Ideas.AddRange(ideas);

            context.SaveChanges();
        }
    }
}