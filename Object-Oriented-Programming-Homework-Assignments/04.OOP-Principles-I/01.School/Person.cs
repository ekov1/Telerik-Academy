namespace _01.School
{
    public abstract class Person
    {
        private string name;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
    }
}
