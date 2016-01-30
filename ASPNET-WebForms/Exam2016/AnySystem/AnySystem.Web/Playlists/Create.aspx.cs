namespace AnySystem.Web.Playlists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services;

    public partial class Create : System.Web.UI.Page
    {
        private PlaylistsService service;

        private CategoriesService categoriesService;

        public Create()
        {
            this.service = new PlaylistsService();
            this.categoriesService = new CategoriesService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<Playlist> Select()
        {
            return null;
        }

        public void fVInsert_InsertItem()
        {
            var playlistToInsert = new Playlist();

            TryUpdateModel(playlistToInsert);

            playlistToInsert.CreatorId = User.Identity.GetUserId();
            playlistToInsert.CreatedOn = DateTime.Now;

            this.service.Create(playlistToInsert);
        }

        public IEnumerable<Category> ddlCategories_GetData()
        {
            return this.categoriesService.GetAll().ToList();
        }

        protected void Unnamed_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 3;
        }


        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}