namespace AnySystem.Web.Playlists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Services;

    public partial class Search : System.Web.UI.Page
    {
        private PlaylistsService service;

        public Search()
        {
            this.service = new PlaylistsService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var contains = Request.QueryString["contains"] != null ? Request.QueryString["contains"].ToLower() : "video";

            this.searchQueryText.InnerText = contains;
        }

        public IEnumerable<PlaylistViewModel> lv_results_Select()
        {
            var contains = Request.QueryString["contains"] != null ? Request.QueryString["contains"].ToLower() : "video";

            this.searchQueryText.InnerText = contains;

            var playlists = this.service.GetAll().Where(x => x.Title.ToLower().Contains(contains) || x.Description.ToLower().Contains(contains)).ToList();

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