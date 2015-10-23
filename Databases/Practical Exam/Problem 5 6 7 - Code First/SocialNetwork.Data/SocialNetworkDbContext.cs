namespace SocialNetwork.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Migrations;
    using Models;

    public class SocialNetworkDbContext : DbContext, ISocialNetworkDbContext
    {
        private const string ConnectionString = "SocialNetworkDb";

        public SocialNetworkDbContext()
            : base(ConnectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SocialNetworkDbContext>());
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());
        }

        public IDbSet<UserProfile> Users { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Friendship> Friendships { get; set; }

        public IDbSet<ChatMessage> ChatMessages { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
