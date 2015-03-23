namespace _02.StudentsAndWorkers
{
    class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

    }
}
