using System;
using System.Linq;


namespace _01.DefineClass
{
    class CallHistoryTest
    {
        public static MobilePhone NokiaPhone = new MobilePhone("Nokia 6300", "Nokia", "Peter", 219, new Battery("2000mAh", BatteryType.NiCd), new Display(3.2));

        public static void Test()
        {
            NokiaPhone.AddCalls(new Call(new DateTime(2015, 02, 15), "0885555558", 521));
            NokiaPhone.AddCalls(new Call(new DateTime(2015, 03, 11), "0885545558", 361));
            NokiaPhone.AddCalls(new Call(new DateTime(2015, 03, 12), "0885545558", 62));
            NokiaPhone.AddCalls(new Call(new DateTime(2015, 03, 13), "0885545558", 602));

            foreach (var call in NokiaPhone.CallHistory)
            {
                Console.WriteLine(call);
                Console.WriteLine();
            }

            Console.WriteLine("\nCost for all registered outgoing calls: {0:C}", NokiaPhone.CallCost(0.37M));

            Call longestCall = NokiaPhone.CallHistory.OrderBy(x => x.Duration).LastOrDefault();

            NokiaPhone.DeleteCalls(longestCall);

            Console.WriteLine("\nCost for all registered outgoing calls (with the longest not counting): {0:C}", NokiaPhone.CallCost(0.37M));

            NokiaPhone.ClearCalls();

            foreach (var call in NokiaPhone.CallHistory)
            {
                Console.WriteLine(call);
                Console.WriteLine();
            }
        }
    }
}
