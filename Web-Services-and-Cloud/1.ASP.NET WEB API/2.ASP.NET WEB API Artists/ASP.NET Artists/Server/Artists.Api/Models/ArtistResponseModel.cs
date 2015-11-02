namespace Artists.Api.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Artists.Models;
    using Infrastructure.Mapping;

    public class ArtistResponseModel : IMapFrom<Artist>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        public List<AlbumResponseModel> Albums { get; set; } 
    }
}