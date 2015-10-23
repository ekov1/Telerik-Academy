namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private ICollection<UserProfile> taggedUsers;

        public Post()
        {
            this.taggedUsers = new HashSet<UserProfile>();
        }

        public int Id { get; set; }

        [MinLength(10)]
        public string Content { get; set; }

        public DateTime PostingDate { get; set; }

        public virtual ICollection<UserProfile> TaggedUsers
        {
            get { return this.taggedUsers; }
            set { this.taggedUsers = value; }
        }
    }
}
