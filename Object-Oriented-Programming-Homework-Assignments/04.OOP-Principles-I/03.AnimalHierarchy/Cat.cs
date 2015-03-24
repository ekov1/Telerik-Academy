using System;

namespace _03.AnimalHierarchy
{
    public abstract class Cat : Animal, ISound
    {
        public Cat(int age, string name, sex _sex)
            :base(age, name, _sex)
        {
        }

        public Cat(int age, string name)
            : base(age, name)
        {
        }


        public void MakeSound()
        {
            Console.WriteLine("Meow! Meow!");
        }
    }
}
