namespace AnySystem.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;

    public class CategoriesService
    {
        private IApplicationDbContext context;

        public CategoriesService()
        {
            this.context = new ApplicationDbContext();
        }

        public IQueryable<Category> GetAll()
        {
            return this.context.Categories;
        }

        public void UpdateCategory(int id, string name)
        {
            var category = this.context.Categories.First(x => x.Id == id);
            category.Name = name;

            this.context.SaveChanges();
        }

        public void AddCategory(Category category)
        {
            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }

        public int GetPlaylistCount(int id)
        {
            var cat = this.context.Categories.FirstOrDefault(x => x.Id == id);
            return cat.Playlists.Count;
        } 
    }
}
