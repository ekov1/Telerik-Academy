namespace SocialNetwork.ConsoleClient.XmlImporter
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Models;

    public class XmlReader
    {
        private const string FilePath = "..\\..\\XmlFiles";

        private static DateTime defaultNullDate = DateTime.Parse("1/1/0001 12:00:00 AM");

        private static Dictionary<string, UserProfile> addedUsers = new Dictionary<string, UserProfile>();

        // Apologies for the long method
        public static void ImportFriendshipDataFromXml(SocialNetworkDbContext data)
        {
            data.Configuration.AutoDetectChangesEnabled = false;
            data.Configuration.ValidateOnSaveEnabled = false;

            var friendshipsFile = Path.Combine(FilePath, "Friendships.xml");

            var serializer = new XmlSerializer(typeof(Friendships));

            var stringXml = File.ReadAllText(friendshipsFile);

            var friendships = (Friendships)serializer.Deserialize(new StringReader(stringXml));

            var allFriendships = friendships.Friendship;

            Console.WriteLine("Importing user data from " + friendshipsFile);
            foreach (var friendship in allFriendships)
            {
                var dateToParse = Convert.ToDateTime(friendship.FriendsSince);

                var friendshipData = new Friendship
                {
                    IsApproved = friendship.Approved
                };

                // This is necessary because a NULL string is converted to 1/1/0001 Date, which in turn is not supported by SQL
                if (dateToParse == defaultNullDate)
                {

                    friendshipData.DateOfApproval = null;
                }
                else
                {
                    friendshipData.DateOfApproval = dateToParse;
                }


                var user1Username = friendship.FirstUser.Username;
                var user1UNameToLower = user1Username.ToLower();

                UserProfile profile1;

                // Checks if there is a user that is already added in the Db
                if (!addedUsers.ContainsKey(user1UNameToLower))
                {
                    profile1 = new UserProfile
                    {
                        Username = user1Username,
                        FirstName = friendship.FirstUser.FirstName,
                        LastName = friendship.FirstUser.LastName,
                        RegisteredOn = friendship.FirstUser.RegisteredOn
                    };

                    AddImagesToProfile(profile1, friendship.FirstUser, null);

                    addedUsers.Add(user1UNameToLower, profile1);

                    data.Users.Add(profile1);
                }
                else
                {
                    profile1 = addedUsers[user1UNameToLower];
                }

                var user2Username = friendship.SecondUser.Username;
                var user2UNameToLower = user2Username.ToLower();

                UserProfile profile2;

                // Checks if there is a user that is already added in the Db
                if (!addedUsers.ContainsKey(user2UNameToLower))
                {
                    profile2 = new UserProfile
                    {
                        Username = user2Username,
                        FirstName = friendship.SecondUser.FirstName,
                        LastName = friendship.SecondUser.LastName,
                        RegisteredOn = friendship.SecondUser.RegisteredOn,
                    };

                    AddImagesToProfile(profile2, null, friendship.SecondUser);

                    addedUsers.Add(user2UNameToLower, profile2);

                    data.Users.Add(profile2);
                }
                else
                {
                    profile2 = addedUsers[user2UNameToLower];
                }

                friendshipData.FirstUser = profile1;
                friendshipData.SecondUser = profile2;

                data.Friendships.Add(friendshipData);

                var messages = friendship.Messages;

                AddMessagesToProfile(messages, data, friendshipData, addedUsers);
            }

            data.SaveChanges();

            Console.WriteLine("Imported all data from " + friendshipsFile);
        }

        public static void ImportPostsDataFromXml(SocialNetworkDbContext data)
        {
            data.Configuration.AutoDetectChangesEnabled = false;
            data.Configuration.ValidateOnSaveEnabled = false;

            var postsFile = Path.Combine(FilePath, "Posts.xml");

            var serializer = new XmlSerializer(typeof(Posts));

            var stringXml = File.ReadAllText(postsFile);

            var posts = (Posts)serializer.Deserialize(new StringReader(stringXml));

            var allPosts = posts.Post;

            Console.WriteLine("Importing posts from " + postsFile);
            foreach (var post in allPosts)
            {
                var postToAdd = new Post
                {
                    Content = post.Content,
                    PostingDate = post.PostedOn
                };

                var taggedUsersUserNames = post.Users.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var username in taggedUsersUserNames)
                {
                    postToAdd.TaggedUsers.Add(addedUsers[username.ToLower()]);
                }

                data.Posts.Add(postToAdd);
                Console.Write(".");
            }

            Console.WriteLine(Environment.NewLine + "Currently saving to Db, please be patient...");

            data.SaveChanges();

            Console.WriteLine("Imported all posts from " + postsFile);
        }

        private static void AddMessagesToProfile(FriendshipsFriendshipMessage[] xmlMessages, SocialNetworkDbContext data, Friendship friendship, Dictionary<string, UserProfile> users)
        {
            for (int i = 0; i < xmlMessages.Length; i++)
            {
                var message = new ChatMessage
                {
                    AuthorUser = users[xmlMessages[i].Author.ToLower()],
                    Content = xmlMessages[i].Content,
                    SentOn = xmlMessages[i].SentOn,
                    Friendship = friendship
                };

                var parsedMessageDate = Convert.ToDateTime(xmlMessages[i].SeenOn);

                if (parsedMessageDate == defaultNullDate)
                {
                    message.SeenOn = null;
                }
                else
                {
                    message.SeenOn = parsedMessageDate;
                }

                data.ChatMessages.Add(message);
            }
        }

        private static void AddImagesToProfile(UserProfile profile, FriendshipsFriendshipFirstUser firstUser, FriendshipsFriendshipSecondUser secondUser)
        {
            dynamic images;

            if (firstUser == null)
            {
                images = secondUser.Images;
            }
            else
            {
                images = firstUser.Images;
            }

            for (int i = 0; i < images.Length; i++)
            {
                profile.Images.Add(new Image
                {
                    FileExtension = images[i].FileExtension,
                    Url = images[i].ImageUrl
                });
            }
        }
    }
}
