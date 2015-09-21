using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        /// <summary>
        /// Please note that I am working with indices of a list, because the order of characters does not change
        /// If you were to work with the same objects, which only get overwritten to have their properties changed
        /// you would be better off working with a dictionary
        /// </summary>
        static void Main()
        {
            var got = new GameOfThrones();

            got.Characters.AddRange(new ICharacter[]{
                new Character("Melisandre"), 
                new Character("Renly"), 
                new Character("Olly"), 
                new Character("Jon Snow"), 
                new Character("Roose Bolton"), 
                new Character("Robb")
            });

            var originalState = got.SaveMemento();

            got.CharactersAlive();

            // Mel kills Renly
            got.Characters[0].Kill(got.Characters[1]);
            // Roose kills Rob
            got.Characters[4].Kill(got.Characters[5]);
            // Snow kills Roose
            got.Characters[3].Kill(got.Characters[4]);
            // Olly kills Snow
            got.Characters[2].Kill(got.Characters[3]);

            Console.WriteLine("\n~~~~~\nAfter character deaths: ");
            got.CharactersAlive();

            got.RestoreMemento(originalState);

            Console.WriteLine("\n~~~~~\nAfter restoring to state from before character deaths occured: ");
            got.CharactersAlive();

            // Olly kills Snow
            got.Characters[2].Kill(got.Characters[3]);

            originalState = got.SaveMemento();

            Console.WriteLine("\n~~~~~\nSaved state where Jon is dead.");

            // Olly kills Mel ?!?!?!
            got.Characters[2].Kill(got.Characters[0]);

            got.CharactersAlive();

            Console.WriteLine("\n~~~~~\nAfter restoring to state from before Melisandre's death occured: ");
            got.RestoreMemento(originalState);

            got.CharactersAlive();


        }
    }
}
