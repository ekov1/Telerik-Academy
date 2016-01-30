namespace AnySystem.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;

    public class UsersService
    {
        private IApplicationDbContext context;

        public UsersService()
        {
            this.context = new ApplicationDbContext();
        }

        public User GetUserById(string id)
        {
            return this.context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(string id, User user)
        {
            var userToUpdate = this.context.Users.First(x => x.Id == id);

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.FacebookUrl = user.FacebookUrl;
            userToUpdate.YoutubeUrl = user.YoutubeUrl;
            userToUpdate.ProfileImageUrl = user.ProfileImageUrl ?? userToUpdate.ProfileImageUrl;

            this.context.SaveChanges();
        }
    }
}
