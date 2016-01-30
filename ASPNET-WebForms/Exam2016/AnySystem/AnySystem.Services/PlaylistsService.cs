namespace AnySystem.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Data.Models;

    public class PlaylistsService
    {
        private IApplicationDbContext context;

        public PlaylistsService()
        {
            this.context = new ApplicationDbContext();
        }

        public IQueryable<Playlist> GetAll()
        {
            return this.context.Playlists
                .Include("Creator")
                .Include("Category")
                .Include("Ratings");
        }

        public IQueryable<Playlist> GetTop(int count)
        {
            return this.context.Playlists
                .Include("Creator")
                .Include("Category")
                .Include("Ratings")
                .OrderByDescending(x => x.Ratings.Count).Take(count);
        }

        public IQueryable<Playlist> GetByUser(string userId)
        {
            return this.context.Users.First(x => x.Id == userId).Playlists.AsQueryable();
        }

        public Playlist GetById(int id)
        {
            return this.context.Playlists.Include("Creator").Include("Category").Include("Ratings").Include("Videos").FirstOrDefault(x => x.Id == id);
        }

        public void Create(Playlist playlist)
        {
            this.context.Playlists.Add(playlist);
            this.context.SaveChanges();
        }

        public void RemoveById(int id)
        {
            var playlist = this.context.Playlists.First(x => x.Id == id);
            this.context.Playlists.Remove(playlist);

            this.context.SaveChanges();
        }
    }
}
