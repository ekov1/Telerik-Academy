namespace AnySystem.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using Data.Models;
    using Models;
    using Services;

    public partial class _Default : Page
    {
        private PlaylistsService service;

        public _Default()
        {
            this.service = new PlaylistsService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<PlaylistViewModel> lv_top_Select()
        {
            var playlists = this.service.GetTop(10).ToList();

            var mappedPlaylists = new List<PlaylistViewModel>();

            playlists.ForEach(x => mappedPlaylists.Add(new PlaylistViewModel {
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