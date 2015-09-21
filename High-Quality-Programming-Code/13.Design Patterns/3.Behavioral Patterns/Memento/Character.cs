using System;
namespace Memento
{
    public class Character : ICharacter
    {
        private ICharacter c;

        public Character(string name)
        {
            this.Name = name;
            this.IsAlive = true;
        }

        //
        // This constructor's purpose is entirely for making a deep copy of the object type
        //
        public Character(ICharacter c)
        {
            foreach (var property in typeof(Character).GetProperties())
            {
                property.SetValue(this, property.GetValue(c));
            }
        }

        public string Name { get; set; }

        public bool IsAlive { get; set; }

        public void Kill(ICharacter target)
        {
            Console.WriteLine("\nXXXXX " + this.Name + " murdered " + target.Name + " XXXXX\n");
            target.IsAlive = false;
        }
    }
}
