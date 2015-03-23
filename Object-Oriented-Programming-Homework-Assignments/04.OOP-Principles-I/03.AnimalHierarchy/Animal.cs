namespace _03.AnimalHierarchy
{
    public enum sex
    {
        male, female
    }
    
    public abstract class Animal
    {
        private int age;
        private string name;
        private sex _sex;

        public Animal(int age, string name, sex _sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = _sex;
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public sex Sex
        {
            get { return _sex; }
            private set { _sex = value; }
        }


    }
}
