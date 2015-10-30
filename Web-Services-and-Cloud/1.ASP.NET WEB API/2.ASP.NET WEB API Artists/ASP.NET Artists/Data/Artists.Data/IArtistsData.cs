namespace Artists.Data
{
    using Models;
    using Repository;

    public interface IArtistsData
    {
        IRepository<Artist> Artists { get; set; }

        IRepository<Song> Songs { get; set; }

        IRepository<Album> Albums { get; set; } 
    }
}
