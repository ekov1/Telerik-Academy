using System;

namespace _03.AnimalHierarchy
{
    /// <summary>
    /// TODO: FINISH
    /// </summary>
    public abstract class Cat : Animal, ISound
    {
        //TODO

        public void MakeSound()
        {
            Console.WriteLine("Meow! Meow!");
        }
    }
}
