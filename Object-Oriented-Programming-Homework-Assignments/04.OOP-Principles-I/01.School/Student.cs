namespace _01.School
{
    public class Student : Person, IComment
    {
        private ulong uniqueNumber;
        private string comment;

        public Student(string name, ulong uniqueNumber) : base(name)
        {
            this.UniqueNumber = uniqueNumber;
        }

        public ulong UniqueNumber
        {
            get { return uniqueNumber; }
            set { uniqueNumber = value; }
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
