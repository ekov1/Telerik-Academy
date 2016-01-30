namespace AnySystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            DataSeed.SeedUsers(context);
            DataSeed.SeedCategories(context);
            DataSeed.SeedPlaylists(context);
        }
    }
}
