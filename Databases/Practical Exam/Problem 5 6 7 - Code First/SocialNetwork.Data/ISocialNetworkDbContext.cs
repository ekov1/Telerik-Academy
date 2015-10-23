namespace SocialNetwork.Data
{
    using System.Data.Entity;
    using Models;

    public interface ISocialNetworkDbContext
    {
        IDbSet<UserProfile> Users { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Friendship> Friendships { get; set; }

        IDbSet<ChatMessage> ChatMessages { get; set; }

        void SaveChanges();
    }
}
