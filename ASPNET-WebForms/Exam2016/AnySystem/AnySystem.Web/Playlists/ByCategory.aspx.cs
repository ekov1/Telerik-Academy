namespace AnySystem.Web.Playlists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Services;

    public partial class ByCategory : System.Web.UI.Page
    {
        private PlaylistsService service;

        public ByCategory()
        {
            this.service = new PlaylistsService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<PlaylistViewModel> lv_categories_Select()
        {
            var catId = int.Parse(Request.QueryString["id"]);

            var playlists = this.service.GetAll().Where(x => x.CategoryId == catId).ToList();

            var mappedPlaylists = new List<PlaylistViewModel>();

            playlists.ForEach(x => mappedPlaylists.Add(new PlaylistViewModel
            {
                Title = x.Title,
                Author = x.Creator.FirstName + " " + x.Creator.LastName,
                Id = x.Id,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Rating = string.Format("{0:0.00}", (double)x.Ratings.Select(r => r.Value).Sum() / x.Ratings.Count)
            }));

            return mappedPlaylists;
        }
    }
}