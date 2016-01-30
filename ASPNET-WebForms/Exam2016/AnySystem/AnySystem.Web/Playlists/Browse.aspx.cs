namespace AnySystem.Web.Playlists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Services;

    public partial class Browse : System.Web.UI.Page
    {
        private PlaylistsService service;

        public Browse()
        {
            this.service = new PlaylistsService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetAuthorName(int id)
        {
            return this.service.GetById(id).Creator.Email;
        }

        public string GetCategoryName(int id)
        {
            return this.service.GetById(id).Category.Name;
        }

        public string GetVideosCount(int id)
        {
            return this.service.GetById(id).Videos.Count.ToString();
        }

        public string GetRating(int id)
        {
            var playlist = this.service.GetById(id);

            return string.Format("{0:0.00}", (double) playlist.Ratings.Select(r => r.Value).Sum()/playlist.Ratings.Count);
        }

        public IQueryable<Playlist> Select()
        {
            return this.service.GetAll().OrderBy(x => x.Id);
        }

        public void SearchContains_OnClick(Object sender, EventArgs e)
        {
            var searchTerms = searchContains.Text ?? "";

            Response.Redirect("~/Playlists/Search?contains=" + searchTerms);
        }
    }
}