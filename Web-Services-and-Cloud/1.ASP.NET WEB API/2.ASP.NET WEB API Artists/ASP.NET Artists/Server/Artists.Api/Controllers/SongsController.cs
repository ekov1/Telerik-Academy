namespace Artists.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Artists.Models;
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
            var song = data.Songs
                .All()
                .ProjectTo<SongResponseModel>()
                .ToList();

            return this.Ok(song);
        }

        public IHttpActionResult Get(int id)
        {
            var song = data.Songs
                .Find(x => x.Id == id)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("No song with that Id was found!");
            }

            return this.Ok(song);
        }

        public IHttpActionResult Post([FromBody] SongResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var song = new Song
            {
                Title = model.Title,
                Year = model.Year,
                Duration = model.Duration
            };

            this.data.Songs.Add(song);
            this.data.SaveChanges();

            return this.Ok(song.Id);
        }

        public IHttpActionResult Put(int id, [FromBody] SongResponseModel model)
        {
            var song = data.Songs
                .Find(x => x.Id == id)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("No song with that Id was found!");
            }

            song.Title = model.Title;
            song.Duration = model.Duration;
            song.Year = model.Year;

            this.data.Songs.Update(song);
            this.data.SaveChanges();

            return this.Ok(song);
        }

        public IHttpActionResult Delete(int id)
        {

            var song = data.Songs
                .Find(x => x.Id == id)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("No song with that Id was found!");
            }

            this.data.Songs.Delete(song);
            this.data.SaveChanges();

            return this.Ok(song);
        }
    }
}