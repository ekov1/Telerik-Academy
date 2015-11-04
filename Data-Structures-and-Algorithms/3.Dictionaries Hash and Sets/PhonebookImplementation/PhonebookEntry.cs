namespace PhonebookImplementation
{
    public class PhonebookEntry
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return string.Format(FirstName + " " + MiddleName + " " + LastName + " " + Nickname + " | " +
                   Town + " | " + PhoneNumber).Trim();
        }
    }
}
