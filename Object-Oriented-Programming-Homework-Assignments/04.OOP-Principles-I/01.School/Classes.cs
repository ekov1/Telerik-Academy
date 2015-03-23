using System.Collections.Generic;

namespace _01.School
{
    public class Classes :IComment
    {
        private string identifier;
        private string comment;
        private List<Student> students;
        private List<Teacher> teachers;

        public Classes(string identifier, List<Student> students, List<Teacher> teachers)
        {
            this.Identifier = identifier;
            this.Students = students;
            this.Teachers = teachers;
        }

        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }

        public List<Student> Students
        {
            get { return students; }
            private set { students = value; }
        }

        public List<Teacher> Teachers
        {
            get { return teachers; }
            private set { teachers = value; }
        }

        public string Comment
        {
            get { return comment; }
            private set { comment = value; }
        }

        public void AddComment(string text)
        {
            this.Comment = text;
        }
    }
}
