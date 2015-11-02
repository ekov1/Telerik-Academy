using System.ComponentModel.DataAnnotations;
namespace StudentSystem.Web.Models
{
    public class StudentResponseModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Level { get; set; }
    }
}