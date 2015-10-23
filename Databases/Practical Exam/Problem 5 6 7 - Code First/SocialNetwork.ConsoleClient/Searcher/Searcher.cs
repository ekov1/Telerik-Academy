namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class DataSearcher
    {
        private static string JsonResultFiles = "../../JsonResults";

        public static void Search(ISocialNetworkService searcher)
        {
            if (!Directory.Exists(JsonResultFiles))
            {
                Directory.CreateDirectory(JsonResultFiles);
            }

            var users = searcher.GetUsersAfterCertainDate(2013);
            var postsByUsers = searcher.GetPostsByUser("ZtlKYHVN7h8SwMmaJs");
            var friendships = searcher.GetFriendships(2, 10);
            var chatUsers = searcher.GetChatUsers("ZtlKYHVN7h8SwMmaJs");

            var usersJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            var postsByUsersJson = JsonConvert.SerializeObject(postsByUsers, Formatting.Indented);
            var chatUsersJson = JsonConvert.SerializeObject(chatUsers, Formatting.Indented);
            var friendshipsJson = JsonConvert.SerializeObject(friendships, Formatting.Indented);


            var jsons = new List<string>
            {
                usersJson,
                postsByUsersJson,
                chatUsersJson,
                friendshipsJson
            };

            Console.WriteLine("Generating query results into /JsonResults");
            for (int i = 1; i <= jsons.Count; i++)
            {
                var filePath = Path.Combine(JsonResultFiles, string.Format("Result{0}.json", i));

                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(jsons[i - 1]);
                }
            }
        }
    }
}
