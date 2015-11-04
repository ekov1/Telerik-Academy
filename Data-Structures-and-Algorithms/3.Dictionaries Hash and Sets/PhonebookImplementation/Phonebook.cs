namespace PhonebookImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        private readonly Dictionary<int, PhonebookEntry> entries;

        public Phonebook()
        {
            this.entries = new Dictionary<int, PhonebookEntry>();
        }

        public void Add(string entry)
        {
            var entryParts = entry.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(str => str.Trim()).ToList();
            var pbEntry = new PhonebookEntry();

            var names = entryParts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (names.Length)
            {
                case 1:
                    pbEntry.Nickname = names[0];
                    break;
                case 2:
                    pbEntry.FirstName = names[0];
                    pbEntry.LastName = names[1];
                    break;
                case 3:
                    pbEntry.FirstName = names[0];
                    pbEntry.MiddleName = names[1];
                    pbEntry.LastName = names[2];
                    break;
                default:
                    throw new ArgumentException();
            }

            pbEntry.Town = entryParts[entryParts.Count - 2];
            pbEntry.PhoneNumber = entryParts[entryParts.Count - 1];

            entries.Add(entry.GetHashCode(), pbEntry);
        }

        public void Add(PhonebookEntry entry)
        {
            entries.Add(entry.GetHashCode(), entry);
        }

        public ICollection<PhonebookEntry> Find(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return entries.Select(x => x.Value).ToList();
            }

            return entries.Where(x => 
            x.Value.Nickname == name 
                || x.Value.FirstName + " " + x.Value.LastName == name
                || x.Value.FirstName + " " + x.Value.MiddleName + " " + x.Value.LastName == name)
                    .Select(x => x.Value).ToList();
        }

        public ICollection<PhonebookEntry> Find(string name, string town)
        {
            return this.Find(name).Where(x => x.Town == town).ToList();
        }
    }
}
