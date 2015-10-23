namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserProfile
    {
        private ICollection<Image> images;
        private ICollection<Post> postsTaggedIn; 

        public UserProfile()
        {
            this.images = new HashSet<Image>();
            this.postsTaggedIn = new HashSet<Post>();
        }

        public int Id { get; set; }

        [MinLength(4)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Post> PostsTaggedIn
        {
            get { return this.postsTaggedIn; }
            set { this.postsTaggedIn = value; }
        } 
    }
}
