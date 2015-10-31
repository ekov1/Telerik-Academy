namespace Artists.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;

    public class SongsController : ApiController
    {
        private IArtistsData data;

        public SongsController()
        {
            this.data = new ArtistsData();
        }

        public IHttpActionResult Get()
        {
            var res = data.Songs
                .All()
                .ProjectTo<SongResponseModel>()
                .ToList();

            return this.Ok(res);
        }

        public IHttpActionResult Get(string title)
        {
            var res = data.Songs
                .All()
                .ProjectTo<SongResponseModel>()
                .FirstOrDefault(x => x.Title == title);

            return this.Ok(res);
        }
    }
}