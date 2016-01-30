namespace AnySystem.Web.Profile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using Services;

    public partial class Private : System.Web.UI.Page
    {
        private UsersService userService;

        private PlaylistsService playlistService;

        public Private()
        {
            this.userService = new UsersService();
            this.playlistService = new PlaylistsService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public User SelectUser()
        {
            var userId = User.Identity.GetUserId();
            var user = userService.GetUserById(userId);

            return user;
        }

        public IEnumerable<PlaylistViewModel> SelectPlaylists()
        {
            var userId = User.Identity.GetUserId();
            var playlists = playlistService.GetByUser(userId).ToList();

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

        public void UpdateUser(string id)
        {
            var userId = User.Identity.GetUserId();
            var user = new User();

            TryUpdateModel(user);

            this.userService.Update(userId, user);
        }
    }
}