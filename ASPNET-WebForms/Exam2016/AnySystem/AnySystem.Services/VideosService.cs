namespace AnySystem.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;

    public class VideosService
    {
        private IApplicationDbContext context;

        public VideosService()
        {
            this.context = new ApplicationDbContext();
        }

        public IQueryable<Video> GetByPlaylistId(int id)
        {
            return this.context.Playlists.First(x => x.Id == id).Videos.AsQueryable();
        }

        public void RemoveById(int id)
        {
            var video = this.context.Videos.First(x => x.Id == id);
            this.context.Videos.Remove(video);
            this.context.SaveChanges();
        }
    }
}
