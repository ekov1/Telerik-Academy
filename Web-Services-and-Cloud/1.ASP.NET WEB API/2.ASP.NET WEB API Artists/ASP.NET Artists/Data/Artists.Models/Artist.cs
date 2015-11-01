namespace Artists.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Artist
    {
        private ICollection<Album> albums;

        public Artist()
        {
            this.albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
