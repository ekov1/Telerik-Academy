using System;

namespace School
{
    public class Student
    {
        private const int MinId = 10000;
        private const int MaxId = 99999;
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
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

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (value < MinId || value > MaxId)
                {
                    throw new ArgumentOutOfRangeException("value", "Id must be between 10000 and 99999.");
                }

                this.id = value;
            }
        }
    }
}
