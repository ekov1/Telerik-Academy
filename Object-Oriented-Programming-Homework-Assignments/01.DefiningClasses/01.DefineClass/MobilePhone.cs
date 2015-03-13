using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

//Problem 1. Define class

//Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors).
//Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

namespace _01.DefineClass
{
    public class MobilePhone
    {

        private static MobilePhone iPhone4S;
        private string model;
        private string manufacturer;
        private string owner;
        private decimal price;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        public MobilePhone(string model, string manufacturer)
        {
            this.CallHistory = new List<Call>();
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public MobilePhone(string model, string manufacturer, Battery battery, Display display)
            : this(model, manufacturer)
        {
            this.Battery = battery;
            this.Display = display;
        }

        public MobilePhone(string model, string manufacturer, decimal price)
            : this(model, manufacturer)
        {
            this.Price = price;
        }

        public MobilePhone(string model, string manufacturer, string owner, decimal price)
            : this(model, manufacturer, price)
        {
            this.Owner = owner;
        }

        public MobilePhone(string model, string manufacturer, string owner, decimal price, Battery battery, Display display)
            : this(model, manufacturer, owner, price)
        {
            this.Battery = battery;
            this.Display = display;
        }

        static MobilePhone()
        {
            IPhone4S = new MobilePhone("Iphone 4S", "Apple", new Battery("Normal", BatteryType.Li_Ion), new Display(4.7));
        }

        public static MobilePhone IPhone4S { get; private set; }

        public string Model { get; private set; }
        public string Manufacturer { get; private set; }
        public string Owner { get; set; }
        public decimal Price { get; private set; }
        public Battery Battery { get; private set; }
        public Display Display { get; private set; }
        public List<Call> CallHistory
        {
            get { return new List<Call>(this.callHistory); }
            private set { this.callHistory = value; }
        }

        public List<Call> AddCalls(Call call)
        {
            this.callHistory.Add(call);
            return this.callHistory;
        }

        public List<Call> DeleteCalls(Call call)
        {
            this.callHistory.Remove(call);
            return this.callHistory;
        }

        public List<Call> ClearCalls()
        {
            this.callHistory.Clear();
            return this.callHistory;
        }

        public decimal CallCost(decimal price)
        {
            decimal cost = 0;

            foreach (var Call in this.CallHistory)
            {
                cost += (decimal)Call.Duration/60*price;
            }

            return cost;
        }

        public override string ToString()
        {
            return String.Format(@"Model: {0}, 
Manufacturer: {1}, 
Price: {2}, 
Owner: {3}, 
Battery: 
{4}, 
Display: 
{5}",
this.Model ?? "Not provided", this.Manufacturer ?? "Not provided",
this.Price, this.Owner ?? "Not provided", this.Battery.ToString(), this.Display.ToString());
        }

    }
}
