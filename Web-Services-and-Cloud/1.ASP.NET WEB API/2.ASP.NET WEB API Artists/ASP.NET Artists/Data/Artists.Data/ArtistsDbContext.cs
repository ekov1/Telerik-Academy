namespace Artists.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Migrations;
    using Models;

    public class ArtistsDbContext : DbContext, IArtistsDbContext
    {
        public ArtistsDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistsDbContext, Configuration>());
        }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
