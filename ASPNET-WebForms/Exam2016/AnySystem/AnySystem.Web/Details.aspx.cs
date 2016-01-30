namespace AnySystem.Web.Playlists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using Data.Models;
    using Models;
    using Services;

    public partial class Details : Page
    {
        private PlaylistsService service;
        private VideosService videosService;

        public Details()
        {
            this.service = new PlaylistsService();
            this.videosService = new VideosService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public PlaylistViewModel Select()
        {
            var id = int.Parse(Request.QueryString["id"]);

            var playlist = this.service.GetById(id);
            var mappedPlaylist = new PlaylistViewModel
            {
                Author = playlist.Creator.FirstName + " " + playlist.Creator.LastName, 
                Category = playlist.Category.Name,
                CategoryId = playlist.CategoryId,
                Rating = string.Format("{0:0.00}", (double)playlist.Ratings.Select(r => r.Value).Sum() / playlist.Ratings.Count),
                Title = playlist.Title,
                Description = playlist.Description,
                CreatedOn = playlist.CreatedOn
            };

            return mappedPlaylist;
        }

        public IEnumerable<Video> GetPlaylistVideos()
        {
            var id = int.Parse(Request.QueryString["id"]);

            return this.videosService.GetByPlaylistId(id);
        }

        protected virtual void rbl_rating_OnSelectedIndexChanged(Object sender, EventArgs e)
        {
            
        }
    }
}