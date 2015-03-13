using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DefineClass
{
    public class Call
    {
        private DateTime date;
        private string phoneNumber;
        private uint duration;

        public Call(DateTime date, string phoneNumber, uint duration)
        {
            this.Date = date;
            this.PhoneNumber = phoneNumber;
            this.Duration = duration;
        }

        public DateTime Date { get; private set; }
        public string PhoneNumber { get; private set; }
        public uint Duration { get; private set; }

        public override string ToString()
        {
            return String.Format(@"Date of call: {0},
Number: {1},
Call duration: {2} seconds.", this.Date, this.PhoneNumber, this.Duration);
        }
    }
}
