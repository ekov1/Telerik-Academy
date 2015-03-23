namespace _01.School
{
    public class Discipline : IComment
    {
        private string name;
        private int lectures;
        private int exercises;
        private string comment;

        public Discipline(string name, int lectures, int exercises)
        {
            this.Name = name;
            this.Lectures = lectures;
            this.Exercises = exercises;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Lectures
        {
            get { return lectures; }
            private set { lectures = value; }
        }

        public int Exercises
        {
            get { return exercises; }
            private set { exercises = value; }
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
