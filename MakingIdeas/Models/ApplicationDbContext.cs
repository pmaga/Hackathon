﻿using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MakingIdeas.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            DateTime saveTime = DateTime.Now;
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                if (entry.Property("CreatedDate").CurrentValue  is DateTime && (DateTime)entry.Property("CreatedDate").CurrentValue == DateTime.MinValue)
                    entry.Property("CreatedDate").CurrentValue = saveTime;
            }
            return base.SaveChanges();

        }
    }
}