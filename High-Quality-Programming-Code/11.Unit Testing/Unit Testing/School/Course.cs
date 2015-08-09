using System;
using System.Collections.Generic;

namespace School
{
    public class Course
    {
        private const int MaxStudents = 30;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        }

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
                    throw new ArgumentNullException("value", "Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public List<Student> Students { get; private set; }

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
            if (this.Students.Count + 1 > MaxStudents)
            {
                throw new Exception("Course is full, student cannot join.");
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
                throw new Exception("The student hasn't enrolled in the course, therefore cannot leave it!");
            }

            this.Students.Remove(student);
        }
    }
}
