namespace Artists.Api.Models
{
    using System.Collections.Generic;
    using Artists.Models;
    using Infrastructure.Mapping;

    public class AlbumResponseModel : IMapFrom<Album>
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public List<SongResponseModel> Songs { get; set; }
    }
}