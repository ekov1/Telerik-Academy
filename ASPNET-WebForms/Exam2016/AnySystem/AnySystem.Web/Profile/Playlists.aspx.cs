namespace AnySystem.Web.Profile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.ModelBinding;
    using System.Web.UI.WebControls;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using Services;

    public partial class Playlists : System.Web.UI.Page
    {
        private PlaylistsService service;
        private VideosService videosService;

        public Playlists()
        {
            this.service = new PlaylistsService();
            this.videosService = new VideosService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<PlaylistViewModel> SelectPlaylists()
        {
            var userId = User.Identity.GetUserId();

            var playlists = this.service.GetByUser(userId).ToList();

            var mappedPlaylists = new List<PlaylistViewModel>();

            playlists.ForEach(x => mappedPlaylists.Add(new PlaylistViewModel
            {
                Title = x.Title,
                Id = x.Id,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Rating = string.Format("{0:0.00}", (double)x.Ratings.Select(r => r.Value).Sum() / x.Ratings.Count)
            }));

            return mappedPlaylists;
        }

        public IEnumerable<Video> GetPlaylistVideos(int id)
        {
            return this.videosService.GetByPlaylistId(id);
        }

        protected void btnDelete_OnCommand(object sender, CommandEventArgs e)
        {
            var argument = e.CommandArgument.ToString();

            this.service.RemoveById(int.Parse(argument));

            Response.Redirect(Request.RawUrl);
        }

        protected void btnDeleteVideo_OnCommand(object sender, CommandEventArgs e)
        {
            var argument = e.CommandArgument.ToString();

            this.videosService.RemoveById(int.Parse(argument));

            Response.Redirect(Request.RawUrl);
        }
    }
}