namespace StudentSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CourseResponseModel
    {
        [Required]
        string Name { get; set; }

        string Description { get; set; }
    }
}