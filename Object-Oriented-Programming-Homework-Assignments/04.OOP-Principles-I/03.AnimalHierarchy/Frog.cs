using System;

namespace _03.AnimalHierarchy
{
    public class Frog : Animal, ISound
    {
        public Frog(int age, string name, sex _sex) :base(age, name, _sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Croak! Croak!");
        }
    }
}
