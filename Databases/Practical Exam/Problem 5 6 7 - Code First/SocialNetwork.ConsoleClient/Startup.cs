namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Linq;
    using Data;
    using Searcher;
    using SocialNetwork.ConsoleClient.XmlImporter;

    public class Startup
    {
        public static void Main()
        {
            var data = new SocialNetworkDbContext();

            XmlReader.ImportFriendshipDataFromXml(data);

            XmlReader.ImportPostsDataFromXml(data);

            var searcher = new SocialNetworkService();

            DataSearcher.Search(searcher);

        }
    }
}
