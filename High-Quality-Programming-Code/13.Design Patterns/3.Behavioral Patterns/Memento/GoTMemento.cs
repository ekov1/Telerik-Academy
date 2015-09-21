using System.Collections.Generic;

namespace Memento
{
    public class GoTMemento
    {
        public List<ICharacter> Characters = new List<ICharacter>();

        public GoTMemento(List<ICharacter> chars)
        {
            this.Characters.Clear();
            //
            // Makes deep copies of Character objects
            //
            foreach (var c in chars)
            {
                this.Characters.Add(new Character(c));
            }
        }
    }
}
