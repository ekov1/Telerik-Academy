namespace SchoolTest
{
    using System;
    using System.Linq;
    using School;
    using NUnit.Framework;

    [TestFixture]
    public class TestSchool
    {
        private Course validCourse;
        private Student validStudent;
        private School validSchool;

        [SetUp]
        public void Init()
        {
            validCourse = new Course("Pirate Speech");
            validStudent = new Student("Captain Blackbeard", 15982);
            validSchool = new School("Too cool for sCOOL");
        }

        [Test]
        public void SchoolShouldBeCreated()
        {
            var school = new School("Pirate Speech School");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolWithInvalidNameShouldThrow()
        {
            var school = new School("");
        }

        [Test]
        public void SchoolShouldAddStudentCorrectly()
        {
            validSchool.AddStudent(validStudent);

            Assert.IsTrue(validSchool.Students.Any(stud => stud.Name == validStudent.Name && stud.Id == validStudent.Id));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolAddingInvalidStudentShouldThrow()
        {
            Student student = null;
            validSchool.AddStudent(student);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void SchoolAddingAnAlreadyExistingStudentShouldThrow()
        {
            validSchool.AddStudent(validStudent);
            validSchool.AddStudent(validStudent);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolAddingAStudentWithAnIdThatIsAlreadyTakenShouldThrow()
        {
            validSchool.AddStudent(new Student("Cptn Nemo", 12111));
            validSchool.AddStudent(new Student("Cptn Jack", 12111));
        }

        [Test]
        public void SchoolShouldRemoveStudentCorrectly()
        {
            validSchool.AddStudent(validStudent);
            validSchool.RemoveStudent(validStudent);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void SchoolRemovingAStudentWhoHasntJoinedTheSchoolShouldThrow()
        {
            validSchool.AddStudent(validStudent);
            validSchool.RemoveStudent(new Student("Captain Nemo", 12000));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolRemovingInvalidStudentShouldThrow()
        {
            Student student = null;

            validSchool.AddStudent(validStudent);
            validSchool.RemoveStudent(student);
        }

        [Test]
        public void SchoolShouldAddCourseCorrectly()
        {
            validSchool.AddCourse(validCourse);
            Assert.IsTrue(validSchool.Courses.Any(course => course.Name == validCourse.Name));
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void SchoolAddingInvalidCourseShouldThrow()
        {
            Course course = null;
            validSchool.AddCourse(course);
        }

        [Test]
        [ExpectedException(typeof (Exception))]
        public void SchooldAddingCourseThatHasAlreadyBeenAddedShouldThrow()
        {
            validSchool.AddCourse(validCourse);
            validSchool.AddCourse(validCourse);
        }

        [Test]
        public void SchoolShouldRemoveCourseCorrectly()
        {
            validSchool.AddCourse(validCourse);
            Assert.IsTrue(validSchool.Courses.Count == 1);
            validSchool.RemoveCourse(validCourse);
            Assert.IsTrue(validSchool.Courses.Count == 0);

        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolRemovingInvalidCourseShouldThrow()
        {
            Course course = null;

            validSchool.AddCourse(validCourse);
            validSchool.RemoveCourse(course);
        }

        [Test]
        [ExpectedException(typeof (Exception))]
        public void SchoolRemovingACourseThatHasntBeenAddedShouldThrow()
        {
            validSchool.RemoveCourse(validCourse);    
        }

    }
}
