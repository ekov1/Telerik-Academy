namespace SchoolTest
{
    using System;
    using System.Linq;
    using School;
    using NUnit.Framework;

    [TestFixture]
    public class TestCourse
    {
        [Test]
        public void CourseShouldBeCreated()
        {
            var course = new Course("Intermediate Pirate Speech");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseWithInvalidNameShouldThrow()
        {
            var course = new Course("");
        }

        [Test]
        public void CourseShouldAddStudentCorrectly()
        {
            var course = new Course("Intermediate Pirate Speech");
            var student = new Student("Captain Blackbeard", 55764);
            course.AddStudent(student);

            Assert.IsTrue(course.Students.Any(stud => stud.Name == student.Name && stud.Id == student.Id));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseAddingInvalidStudentShouldThrow()
        {
            var course = new Course("Intermediate Pirate Speech");
            Student student = null;
            course.AddStudent(student);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CourseAddingMoreThanThirtyStudentsShouldThrow()
        {
            var course = new Course("1337 sP33cH Course");
            for (int i = 0; i < 30; i++)
            {
                course.AddStudent(new Student(string.Format("Robot P" + i + "esho" + i), 13337 + i));
            }

            course.AddStudent(new Student("Cptn Nemo", 10001));
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CourseAddingAnAlreadyExistingStudentShouldThrow()
        {
            var course = new Course("Just a course");
            var student = new Student("Captain Nemo", 12000);

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [Test]
        public void CourseShouldRemoveStudentCorrectly()
        {
            var course = new Course("course");
            var student = new Student("Captain Blackbeard", 10000);

            course.AddStudent(student);
            course.RemoveStudent(student);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CourseRemovingAStudentWhoHasntEnrolledInTheCourseShouldThrow()
        {
            var course = new Course("course");
            var student = new Student("Captain Blackbeard", 10000);

            course.AddStudent(student);
            course.RemoveStudent(new Student("Captain Nemo", 12000));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseRemovingInvalidStudentShouldThrow()
        {
            var course = new Course("course");
            Student student = null;

            course.AddStudent(new Student("Captain Nemo", 12000));
            course.RemoveStudent(student);
        }
    }
}
