using System;

namespace _01.DefineClass
{
    public enum BatteryType
    {
        Li_Ion, Li_Poly, NiMH, NiCd
    }

    public class Battery
    {
        private string batteryModel;
        private BatteryType type;
        private double hoursIdle;
        private double hoursTalk;
        

        public Battery(string batteryModel, BatteryType type)
        {
            this.BatteryModel = batteryModel;
            this.Type = type;
        }

        public Battery(string batteryModel, double hoursIdle, double hoursTalk, BatteryType type)
        {
            this.BatteryModel = batteryModel;
            this.Type = type;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public Battery(string batteryModel, double hoursIdle, double hoursTalk)
        {
            this.BatteryModel = batteryModel;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public string BatteryModel { get; set; }
        public BatteryType Type { get; set; }
        public double HoursIdle { get; set; }
        public double HoursTalk { get; set; }

        public override string ToString()
        {
            return String.Format(@"Battery Model: {0},
Battery Type: {1},
Battery Idle Work Time: {2} hours,
Battery Talk Time: {3} hours", this.BatteryModel, this.Type, this.HoursIdle, this.HoursTalk);
        }

    }
}
