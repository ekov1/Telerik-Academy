using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DefineClass
{
    class Test
    {
        public static MobilePhone[] phonesArray = 
        {
            new MobilePhone("HTC One Plus One", "HTC", new Battery("Standart", BatteryType.Li_Ion),new Display(5.5)),
            new MobilePhone("Moto X", "Motorola", new Battery("2,300mAh", BatteryType.Li_Poly),new Display(5.2)),
            new MobilePhone("Sony Xperia Z3", "Sony" ,new Battery("3,100mAh", BatteryType.Li_Ion),new Display(5.15)),
            new MobilePhone("Nexus 6", "Google" ,new Battery("3,220mAh", BatteryType.Li_Ion),new Display(5.96)),
            new MobilePhone("Iphone 6 Plus", "Apple" ,new Battery("2,915mAh", BatteryType.Li_Ion),new Display(5.5)) 
        };

        public static void PrintPhones()
        {
            Console.WriteLine(MobilePhone.IPhone4S);
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < phonesArray.Length; i++)
            {
                Console.WriteLine(phonesArray[i]);

                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
