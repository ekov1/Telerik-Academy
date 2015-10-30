namespace Artists.Data
{
    using Models;
    using Repository;

    public class ArtistsData : IArtistsData
    {
        private IArtistsDbContext context;

        public ArtistsData(IArtistsDbContext context)
        {
            this.context = context;

            this.Artists = new Repository<Artist>(this.context);
            this.Songs = new Repository<Song>(this.context);
            this.Albums = new Repository<Album>(this.context);
        }

        public ArtistsData()
            : this(new ArtistsDbContext())
        {
        }

        public IRepository<Artist> Artists { get; set; }

        public IRepository<Song> Songs { get; set; }

        public IRepository<Album> Albums { get; set; } 
    }
}
