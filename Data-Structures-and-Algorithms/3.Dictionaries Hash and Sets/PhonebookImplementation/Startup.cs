namespace PhonebookImplementation
{
    using System;
    using System.IO;
    using System.Linq;

    public static class Startup
    {
        private static string phonesFilepath = "../../Files/phones.txt";
        private static string commandsFilepath = "../../Files/commands.txt";

        public static void Main()
        {
            var entriesFromFile = File.ReadAllLines(phonesFilepath);
            var commandsFromFile = File.ReadAllLines(commandsFilepath);

            var phonebook = new Phonebook();

            foreach (var line in entriesFromFile)
            {
                phonebook.Add(line);
            }

            foreach (var command in commandsFromFile)
            {
                Console.WriteLine("Current command "+ command + Environment.NewLine);
                var c = command.IndexOf("find", StringComparison.InvariantCultureIgnoreCase);

                if (c < 0)
                {
                    Console.WriteLine("Invalid command in file " + commandsFilepath);
                    continue;
                }

                if (command.IndexOf(", ", StringComparison.InvariantCultureIgnoreCase) < 0)
                {
                    var name = command.Substring(c + 4).Trim(new[] { '(', ')' });

                    Console.WriteLine(string.Join(Environment.NewLine, phonebook.Find(name)));
                }
                else
                {
                    var nameAndTown = command.Substring(c + 4).Trim(new[] { '(', ')' }).Split(',').Select(x => x.Trim()).ToList();

                    Console.WriteLine(string.Join(Environment.NewLine, phonebook.Find(nameAndTown[0], nameAndTown[1])));
                }

                Console.WriteLine("-------------------------------------------------------");
            }
        }
    }
}
