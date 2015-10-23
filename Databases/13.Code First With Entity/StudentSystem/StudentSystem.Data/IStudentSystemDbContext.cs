namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Models;

    public interface IStudentSystemDbContext
    {
        IDbSet<Homework> Homeworks { get; set; }
        
        IDbSet<Material> Materials { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<Student> Students { get; set; }

        void SaveChanges();
    }
}
