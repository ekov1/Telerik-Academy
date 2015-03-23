using System.Collections.Generic;

namespace _01.School
{
    public class Teacher :Person, IComment
    {
        private List<Discipline> disciplines;
        private string comment;

        public Teacher(string name, List<Discipline> disciplines) : base(name)
        {
            this.Disciplines = disciplines;
        }

        public List<Discipline> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; }
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
