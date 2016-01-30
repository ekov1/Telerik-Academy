namespace AnySystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IApplicationDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Video> Videos { get; set; }

        IDbSet<Playlist> Playlists { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
