namespace Artists.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using Data;
    using Newtonsoft.Json.Linq;

    public static class Startup
    {
        private static readonly IArtistsData Data = new ArtistsData();
        private static string jsonType = "application/json";
        private static string xmlType = "application/xml";

        public static void Main()
        {
            Console.WriteLine("Please standby, Thread.Sleep is used to simulate async environment.");
            Thread.Sleep(3000);

            var uri = new Uri("http://localhost:53888/");

            PostTest(uri, "api/artists");
            PostAlbums(uri, "api/albums");

            GetAlbums(uri, "api/albums");

            Console.ReadLine();
        }

        private static async void PostTest(Uri uri, string apiPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;

                var artist = JObject.Parse(@"{ ""Name"": ""Justin Bieber"", ""Country"": ""Canada""}");

                var res = await httpClient.PostAsync(
                    apiPath,
                    new StringContent(
                        artist.ToString(),
                        Encoding.UTF8,
                        jsonType));

                var resContent = await res.Content.ReadAsStringAsync();

                Console.WriteLine("Added Artist with Id: " + resContent);
            }
        }

        private static async void PostAlbums(Uri uri, string apiPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;

                var album = JObject.Parse(@"{ ""Title"": ""#Omri"", ""Year"": ""2012"", ""Producer"": ""Usher"" }");

                var res = await httpClient.PostAsync(
                    apiPath,
                    new StringContent(
                        album.ToString(),
                        Encoding.UTF8,
                        jsonType));

                var resContent = await res.Content.ReadAsStringAsync();

                Console.WriteLine("Added Album with Id: " + resContent);
            }
        }

        private static async void GetAlbums(Uri uri, string apiPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(xmlType));

                var response = await httpClient.GetAsync(apiPath);

                Console.WriteLine(Environment.NewLine + "Albums: " + await response.Content.ReadAsStringAsync());
            }
        }

    }
}
