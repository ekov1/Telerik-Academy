using System;

namespace _03.AnimalHierarchy
{
    public class Dog : Animal, ISound
    {
        public Dog (int age, string name, sex _sex) :base(age, name, _sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Wuff! Wuff!");
        }
    }
}
