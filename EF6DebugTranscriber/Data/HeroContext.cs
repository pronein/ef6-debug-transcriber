using System;
using System.Data.Entity;
using System.Reflection;
using EF6DebugTranscriber.Data.Entities;

namespace EF6DebugTranscriber.Data {
    public class HeroContext : DbContext {
        public DbSet<HeroEntity> Heros { get; set; }

        public HeroContext() : base("name=HerosDbConnectionString") {
            Database.Log = Console.WriteLine;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
