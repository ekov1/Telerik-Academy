namespace _02.StudentsAndWorkers
{
    class Worker :Human
    {
        private double weekSalary;
        private double workHours;

        public Worker(string firstName, string lastName, double weekSalary, double workHours)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHours = workHours;
        }

        public double WeekSalary
        {
            get { return weekSalary; }
            set { weekSalary = value; }
        }

        public double WorkHours
        {
            get { return workHours; }
            set { workHours = value; }
        }


        public double MoneyPerHour()
        {
            double moneyPerHour = this.WeekSalary/this.WorkHours*5;
            return moneyPerHour;
        }
    }
}
