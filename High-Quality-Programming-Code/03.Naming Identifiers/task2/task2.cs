namespace task2
{
    class Program
    {
        public void Main(int id)
        {
            var person = new Human();
            person.Age = id;

            if (id % 2 == 0)
            {
                person.Name = "Батката";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Мацето";
                person.Gender = Gender.Female;
            }
        }
    }

    public enum Gender { Male, Female };

    public class Human
    {
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
