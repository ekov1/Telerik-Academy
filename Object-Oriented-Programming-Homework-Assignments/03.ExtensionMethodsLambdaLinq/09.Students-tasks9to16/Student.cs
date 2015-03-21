using System.Collections.Generic;

namespace _09.Students_tasks9to16
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string fN;
        private string tel;
        private string email;
        private List<int> marksList;
        private Group group;

        public Student(string firstName, 
            string lastName, 
            string fN, 
            string tel, 
            string email, 
            List<int> marksList,
            Group group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fN;
            this.Tel = tel;
            this.Email = email;
            this.MarksList = marksList;
            this.Group = group;
        }

        public string FirstName
        {
            get { return firstName; }
            private set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            private set { lastName = value; }
        }

        public string FN
        {
            get { return fN; }
            private set { fN = value; }
        }

        public string Tel
        {
            get { return tel; }
            private set { tel = value; }
        }

        public string Email { get; set; }

        public List<int> MarksList
        {
            get { return marksList; }
            private set { marksList = value; }
        }

        public Group Group
        {
            get { return @group; }
            set { @group = value; }
        }

        public override string ToString()
        {
            return string.Format("Subject: {0}\nSubject last name: {1}\nFaculty number: {2}\n" +
                                 "Group: {3}\nMarks: {4}\nTelephone Number: {5}\nE-mail: {6}",
                this.FirstName, this.LastName, this.FN, this.Group.GroupNumber,
                string.Join(", ", this.MarksList), this.Tel, this.Email);
        }
    }
}
