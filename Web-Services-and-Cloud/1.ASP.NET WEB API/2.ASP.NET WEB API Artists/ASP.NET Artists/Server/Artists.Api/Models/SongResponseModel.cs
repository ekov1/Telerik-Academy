namespace Artists.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Artists.Models;
    using Infrastructure.Mapping;

    public class SongResponseModel : IMapFrom<Song>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public float Duration { get; set; }
    }
}