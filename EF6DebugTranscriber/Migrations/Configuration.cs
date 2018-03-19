namespace EF6DebugTranscriber.Migrations {
    using System.Data.Entity.Migrations;
    using EF6DebugTranscriber.Data;
    using EF6DebugTranscriber.Data.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<HeroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(HeroContext context) {
            RunSeed(context);
        }

        public void RunSeed(HeroContext context) {
            //  This method will be called after migrating to the latest version.
            var heroMage = new HeroEntity { Id = 1, Name = "Raistlin Majere" };
            var heroWarrior = new HeroEntity { Id = 2, Name = "Carmen Majere" };
            var heroPaladin = new HeroEntity { Id = 3, Name = "Sturm Brightblade" };

            var weapon = new GearEntity { Name = "Staff of Magus", Weight = 3f };
            var container = new GearEntity { Name = "Herb Pouch", Weight = .5f };
            var herbs = new GearEntity { Name = "Herbs", Weight = .01f, Container = container };
            var backpack = new GearEntity { Name = "Backpack" };
            var bedroll = new GearEntity { Name = "Bedroll", Weight = 2f, Container = backpack };

            heroMage.Gear.Add(weapon);
            heroMage.Gear.Add(container);

            heroPaladin.Gear.Add(backpack);

            context.Heros.AddOrUpdate(new HeroEntity[] {
                heroMage,
                heroWarrior,
                heroPaladin
            });

            context.Gear.AddOrUpdate(new GearEntity[] {
                herbs,
                bedroll
            });

            context.SaveChanges();
        }
    }
}
