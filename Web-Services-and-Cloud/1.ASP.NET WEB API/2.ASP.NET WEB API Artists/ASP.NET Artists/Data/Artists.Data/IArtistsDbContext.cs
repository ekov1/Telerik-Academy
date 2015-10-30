namespace Artists.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IArtistsDbContext
    {
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
