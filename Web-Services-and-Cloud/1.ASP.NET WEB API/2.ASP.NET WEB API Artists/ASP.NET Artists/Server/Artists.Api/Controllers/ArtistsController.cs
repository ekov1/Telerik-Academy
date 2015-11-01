namespace Artists.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Artists.Models;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;

    public class ArtistsController : ApiController
    {
        private IArtistsData data;

        public ArtistsController()
        {
            this.data = new ArtistsData();
        }

        public IHttpActionResult Get()
        {
            var res = this.data.Artists
                .All()
                .ProjectTo<ArtistResponseModel>()
                .ToList();

            return this.Ok(res);
        }

        public IHttpActionResult Get(int id)
        {
            var res = this.data.Artists
                .Find(x => x.Id == id)
                .ProjectTo<ArtistResponseModel>()
                .FirstOrDefault();

            return this.Ok(res);
        }

        // Register artist
        public IHttpActionResult Post([FromBody] ArtistResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artist = new Artist
            {
                Name = model.Name,
                Country = model.Country
            };

            this.data.Artists.Add(artist);
            this.data.SaveChanges();

            return this.Ok(artist.Id);
        }

        public IHttpActionResult Put(int id, [FromBody] ArtistResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artist = this.data.Artists
                .Find(x => x.Id == id)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("No artist with that Id was found!");
            }

            artist.Country = model.Country;
            artist.Name = model.Name;

            this.data.Artists.Update(artist);
            this.data.SaveChanges();

            return this.Ok(artist);
        }

        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artist = this.data.Artists
                .Find(x => x.Id == id)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("No artist with that Id was found!");
            }

            this.data.Artists.Delete(artist);
            this.data.SaveChanges();

            return this.Ok(artist);
        }
    }
}