namespace Artists.Api.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Artists.Models;
    using Infrastructure.Mapping;

    public class AlbumResponseModel : IMapFrom<Album>
    {
        public AlbumResponseModel()
        {
            this.Songs = new List<SongResponseModel>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Producer { get; set; }

        public List<SongResponseModel> Songs { get; set; }
    }
}