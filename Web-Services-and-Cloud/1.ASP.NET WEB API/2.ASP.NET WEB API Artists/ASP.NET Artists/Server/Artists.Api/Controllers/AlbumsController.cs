namespace Artists.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Artists.Models;
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
            var res = this.data.Albums
                .All()
                .ProjectTo<AlbumsController>()
                .ToList();

            return this.Ok(res);
        }

        public IHttpActionResult Get(string title)
        {
            var res = this.data.Albums
                .All()
                .ProjectTo<AlbumResponseModel>()
                .FirstOrDefault(x => x.Title.ToLowerInvariant() == title.ToLowerInvariant());

            return this.Ok(res);
        }

        public IHttpActionResult Post([FromBody] AlbumResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var album = new Album
            {
                Title = model.Title,
                Year = model.Year,
                Producer = model.Producer
            };

            foreach (var song in model.Songs)
            {
                album.Songs.Add(new Song
                {
                    Title = song.Title,
                    Year = song.Year,
                    Duration = song.Duration
                });
            }

            this.data.Albums.Add(album);
            this.data.SaveChanges();

            return this.Ok(album.Id);
        }

        public IHttpActionResult Put(string title, [FromBody] AlbumResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var album = this.data.Albums
                .Find(x => x.Title.ToLowerInvariant() == title.ToLowerInvariant())
                .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("No album with that name was found!");
            }

            album.Title = model.Title;
            album.Producer = model.Producer;
            album.Year = model.Year;

            var songs = new List<Song>();
            foreach (var song in model.Songs)
            {
                songs.Add(new Song
                {
                    Title = song.Title,
                    Duration = song.Duration,
                    Year = song.Year
                });
            }

            album.Songs = songs;

            var newTitleInData = this.data.Albums.Find(x => x.Title.ToLowerInvariant() == album.Title.ToLowerInvariant())
                .FirstOrDefault();

            if (newTitleInData != null)
            {
                return this.BadRequest("An album with the same title already exists!");
            }

            this.data.Albums.Update(album);
            this.data.SaveChanges();

            return this.Ok(album);
        }

        public IHttpActionResult Delete(string title)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var album = this.data.Albums
                .Find(x => x.Title.ToLowerInvariant() == title.ToLowerInvariant())
                .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("No album with that title was found!");
            }

            return this.Ok(album);
        }
    }
}