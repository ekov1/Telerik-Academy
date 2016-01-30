namespace AnySystem.Web.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Data.Models;
    using Services;

    public partial class Categories : System.Web.UI.Page
    {
        private CategoriesService service;

        public Categories()
        {
            this.service = new CategoriesService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int GetPlaylistsInCategory(int id)
        {
            return this.service.GetPlaylistCount(id);
        }

        public IQueryable<Category> Select()
        {
            return this.service.GetAll().OrderBy(x => x.Id);
        }

        public void Update(int id, string name)
        {
            var editTextBox = this.gvCategories.Rows[this.gvCategories.EditIndex].Controls[1].Controls[0] as TextBox;

            if (editTextBox.Text == null || editTextBox.Text.Length < 2)
            {
                return;
            }

            this.service.UpdateCategory(id, name);
        }

        public void BtnAdd_OnClick(object sender, EventArgs e)
        {
            var text = this.newCategory.Text;

            if (String.IsNullOrEmpty(text))
            {
                literalMsg.Visible = true;
                return;
            }

            this.service.AddCategory(new Category { Name = text });
            this.newCategory.Text = "";

            literalMsg.Visible = false;
        }

    }
}