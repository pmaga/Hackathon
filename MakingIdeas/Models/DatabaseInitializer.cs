using System;
using System.Collections.Generic;

namespace MakingIdeas.Models
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var ideas = new List<Idea>
            {
                new Idea {Title = "Idea 1", Body = "Idea 1 body", CreatedDate = new DateTime(2016, 9, 27)},
                new Idea {Title = "Idea 2", Body = "Idea 2 body", CreatedDate = new DateTime(2016, 9, 29)},
                new Idea {Title = "Idea 3", Body = "Idea 3 body", CreatedDate = new DateTime(2016, 9, 30)},
                new Idea {Title = "Idea 4", Body = "Idea 4 body", CreatedDate = new DateTime(2016, 9, 27)},
                new Idea {Title = "Idea 5", Body = "Idea 5 body", CreatedDate = new DateTime(2016, 9, 26)}
            };

            context.Ideas.AddRange(ideas);

            context.SaveChanges();
        }
    }
}