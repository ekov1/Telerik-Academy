namespace Artists.Api.Models
{
    using Artists.Models;
    using Infrastructure.Mapping;

    public class SongResponseModel : IMapFrom<Song>
    {
        public string Title { get; set; }

        public int Year { get; set; }
    }
}