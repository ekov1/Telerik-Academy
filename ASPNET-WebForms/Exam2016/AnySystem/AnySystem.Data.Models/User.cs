namespace AnySystem.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Playlist> playlists;

        public User()
        {
            this.playlists = new HashSet<Playlist>();
        }

        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string FacebookUrl { get; set; }

        [MaxLength(200)]
        public string YoutubeUrl { get; set; }

        [MaxLength(300)]
        public string ProfileImageUrl { get; set; }

        public virtual ICollection<Playlist> Playlists { get { return this.playlists; } set { this.playlists = value; } }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
