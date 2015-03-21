namespace _09.Students_tasks9to16
{
    public class Group
    {
        private int groupNumber;
        private string department;

        public Group(int groupNumber, string department)
        {
            this.GroupNumber = groupNumber;
            this.Department = department;
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            private set { groupNumber = value; }
        }

        public string Department
        {
            get { return department; }
            private set { department = value; }
        }
    }
}
