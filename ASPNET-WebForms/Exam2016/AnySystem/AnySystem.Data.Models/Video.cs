namespace AnySystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Video
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int PlayListId { get; set; }

        [ForeignKey("PlayListId")]
        public virtual Playlist Playlist { get; set; }
    }
}
