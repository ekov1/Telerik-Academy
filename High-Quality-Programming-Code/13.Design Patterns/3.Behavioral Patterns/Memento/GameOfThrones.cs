using System;
using System.Collections.Generic;

namespace Memento
{
    public class GameOfThrones
    {
        public List<ICharacter> Characters = new List<ICharacter>();

        public void CharactersAlive()
        {
            foreach (var character in this.Characters)
            {
                Console.WriteLine(character.Name + " is " + (character.IsAlive ? "alive" : "!!! dead !!!"));
            }
        }

        public GoTMemento SaveMemento()
        {
            return new GoTMemento(this.Characters);
        }

        public void RestoreMemento(GoTMemento memento)
        {
            this.Characters.Clear();
            //
            // Makes deep copies of Character objects
            //
            foreach (var c in memento.Characters)
            {
                this.Characters.Add(new Character(c));
            }
        }
    }
}
