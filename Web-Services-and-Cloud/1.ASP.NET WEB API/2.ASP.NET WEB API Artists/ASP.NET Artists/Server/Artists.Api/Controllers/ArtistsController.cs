namespace Artists.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Artists.Models;
    using Data;
    using Models;

    public class ArtistsController : ApiController
    {
        private IArtistsData data;

        public ArtistsController()
        {
            this.data = new ArtistsData();
        }

        public IHttpActionResult Get(int size = 10)
        {
            var res = data.Artists
                .All()
                .Take(size)
                .ToList();

            return this.Ok(res);
        }

        // Register artist
        public IHttpActionResult Post(ArtistResponseModel model)
        {
            var artist = new Artist
            {
                Name = model.Name,
                Country = model.Country
            };

            data.Artists.Add(artist);
            data.SaveChanges();

            return this.Ok(artist.Id);
        }
    }
}