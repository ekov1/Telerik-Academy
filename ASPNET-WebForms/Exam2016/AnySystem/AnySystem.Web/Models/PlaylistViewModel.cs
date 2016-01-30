namespace AnySystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using Data.Models;

    public class PlaylistViewModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Id { get; set; }

        public string Rating { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Video> Videos { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}