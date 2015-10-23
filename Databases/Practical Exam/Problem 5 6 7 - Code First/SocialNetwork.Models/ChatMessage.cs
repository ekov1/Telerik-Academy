namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ChatMessage
    {
        public int Id { get; set; }

        public int FriendshipId { get; set; }

        [ForeignKey("FriendshipId")]
        public virtual Friendship Friendship { get; set; }

        public int AuthorUserId { get; set; }

        [ForeignKey("AuthorUserId")]
        public virtual UserProfile AuthorUser { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }
    }
}
