namespace Artists.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;

    public class AlbumsController : ApiController
    {
        private IArtistsData data;

        public AlbumsController()
        {
            this.data = new ArtistsData();
        }

        public IHttpActionResult Get()
        {
            var res = data.Albums
                .All()
                .ProjectTo<AlbumsController>()
                .ToList();

            return this.Ok(res);
        }

        public IHttpActionResult Get(string title)
        {
            var res = data.Albums
                .All()
                .ProjectTo<AlbumResponseModel>()
                .FirstOrDefault(x => x.Title.ToLowerInvariant() == title.ToLowerInvariant());

            return this.Ok(res);
        }
    }
}