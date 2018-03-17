namespace EF6DebugTranscriber.Migrations {
    using System.Data.Entity.Migrations;
    using EF6DebugTranscriber.Data;
    using EF6DebugTranscriber.Data.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<HeroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HeroContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Heros.AddOrUpdate(new HeroEntity[] {
                new HeroEntity{ Name = "Raistlin Majere" },
                new HeroEntity{ Name = "Carmen Majere" },
                new HeroEntity{ Name = "Sturm Brightblade" }
            });

            context.SaveChanges();
        }
    }
}
