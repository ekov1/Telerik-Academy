namespace SocialNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public int Id { get; set; }

        public string Url { get; set; }

        [MaxLength(4)]
        public string FileExtension { get; set; }
    }
}
