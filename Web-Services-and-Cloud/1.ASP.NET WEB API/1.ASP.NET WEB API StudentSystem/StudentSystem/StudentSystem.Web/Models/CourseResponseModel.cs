﻿namespace StudentSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CourseResponseModel
    {
        string Id { get; set; }

        [Required]
        string Name { get; set; }

        string Description { get; set; }
    }
}