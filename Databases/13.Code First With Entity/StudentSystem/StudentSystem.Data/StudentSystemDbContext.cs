namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class StudentSystemDbContext : DbContext, IStudentSystemDbContext
    {
        private const string ConnectionString = "StudentSystemPesho";

        public StudentSystemDbContext()
            : base(ConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Material> Materials { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
