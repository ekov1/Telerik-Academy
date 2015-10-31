namespace Artists.Api.Models
{
    using System.Collections.Generic;
    using Artists.Models;
    using Infrastructure.Mapping;

    public class ArtistResponseModel : IMapFrom<Artist>
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public List<AlbumResponseModel> Albums { get; set; } 
    }
}