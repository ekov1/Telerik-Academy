using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class School
    {
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.Courses = new List<Course>();
            this.Students = new List<Student>();
        }

        public List<Student> Students { get; private set; }

        public List<Course> Courses { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "Student parameter cannot be null.");
            }
            if (this.Students.Contains(student))
            {
                throw new Exception("The student has already enrolled in the course.");
            }
            if (!HasUniqueId(student))
            {
                throw new ArgumentException("Student with the same ID is already present in the Students list.");
            }

            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "Student parameter cannot be null.");
            }
            if (!this.Students.Contains(student))
            {
                throw new Exception("The student hasn't enrolled in the course, therefore they cannot leave!");
            }

            this.Students.Remove(student);
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "Course parameter cannot be null.");
            }
            if (this.Courses.Contains(course))
            {
                throw new Exception("The Course has already been added");
            }

            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "Course parameter cannot be null.");
            }
            if (!this.Courses.Contains(course))
            {
                throw new Exception("There is no such course, therefore it cannot be removed!");
            }

            this.Courses.Remove(course);
        }

        private bool HasUniqueId(Student student)
        {
            return !(this.Students.Any(stud => stud.Id == student.Id));
        }
    }
}
