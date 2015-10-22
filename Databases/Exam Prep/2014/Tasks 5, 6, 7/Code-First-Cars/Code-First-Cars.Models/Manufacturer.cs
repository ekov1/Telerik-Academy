namespace Code_First_Cars.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Name { get; set; }
    }
}
