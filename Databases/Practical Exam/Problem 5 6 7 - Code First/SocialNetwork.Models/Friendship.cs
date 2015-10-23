namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        public int Id { get; set; }

        public int FirstUserId { get; set; }

        [ForeignKey("FirstUserId")]
        public virtual UserProfile FirstUser { get; set; }

        public int SecondUserId { get; set; }

        [ForeignKey("SecondUserId")]
        public virtual UserProfile SecondUser { get; set; }
        
        public DateTime? DateOfApproval { get; set; }

        public bool IsApproved { get; set; }
    }
}
