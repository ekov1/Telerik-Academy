namespace AnySystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Video> Videos { get; set; }

        public IDbSet<Playlist> Playlists { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Video>()
                .HasRequired(v => v.Playlist)
                .WithMany(x => x.Videos)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<Rating>()
                .HasRequired(v => v.Playlist)
                .WithMany(x => x.Ratings)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
