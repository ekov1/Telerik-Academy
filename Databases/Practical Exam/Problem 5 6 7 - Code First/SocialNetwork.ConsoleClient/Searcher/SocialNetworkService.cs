namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class SocialNetworkService : ISocialNetworkService
    {
        private readonly ISocialNetworkDbContext data;

        public SocialNetworkService()
        {
            this.data = new SocialNetworkDbContext();  
        }

        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            var userdata = data.Users.Where(x => x.RegisteredOn.Year >= year).Select(x => new
            {
                Username = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                NumberOfImages = x.Images.Count
            }).ToList();

            return userdata;
        }

        public IEnumerable GetPostsByUser(string username)
        {
            var data = new SocialNetworkDbContext();

            var userdata = data.Posts
                .Where(p => p.TaggedUsers.Select(u => u.Username).Contains(username))
                .Select(p => new
                {
                    PostedOn = p.PostingDate,
                    Content = p.Content,
                    Usernames = p.TaggedUsers.Select(u => u.Username)
                }).ToList();

            return userdata;
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var data = new SocialNetworkDbContext();

            var userdata = data.Friendships
                .Where(f => f.IsApproved)
                .OrderBy(f => f.DateOfApproval)
                .Select(f => new
                {
                    FirstUserUsername = f.FirstUser.Username,
                    FirstUserImage = f.FirstUser.Images.FirstOrDefault(),
                    SecondUserUsername = f.SecondUser.Username,
                    SecondUserImage = f.SecondUser.Images.FirstOrDefault()
                })
                .Skip((page - 1)*pageSize)
                .Take(pageSize);

            return userdata;
        }

        public IEnumerable GetChatUsers(string username)
        {
            var data = new SocialNetworkDbContext();

            var userdata = data.ChatMessages
                .Where(m => m.Friendship.FirstUser.Username == username
                            || m.Friendship.SecondUser.Username == username)
                .Select(m => m.Friendship.FirstUser.Username != username ?
                       m.Friendship.FirstUser.Username 
                       : m.Friendship.SecondUser.Username)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            return userdata;
        }
    }
}
