using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main()
        {
            var femalePrayingMantis = new Mantis("European Mantis", new PassiveBehavior());

            Console.WriteLine("~~~~~\nPassive behavior of a female " + femalePrayingMantis.Species + ":");
            femalePrayingMantis.Behavior.DoWhatAMantisWouldDo();

            femalePrayingMantis.ChangeBehavior(new AggressiveBehavior());

            Console.WriteLine("\n~~~~~\nAggresive behavior of a female " + femalePrayingMantis.Species + ":");
            femalePrayingMantis.Behavior.DoWhatAMantisWouldDo();

            femalePrayingMantis.ChangeBehavior(new SexyBehavior());

            Console.WriteLine("\n~~~~~\nSexy behavior of a female " + femalePrayingMantis.Species + ":");
            femalePrayingMantis.Behavior.DoWhatAMantisWouldDo();

            femalePrayingMantis.ChangeBehavior(new SexualCannibalismBehavior());

            Console.WriteLine("\n~~~~~\nAfter-sex behavior of a female " + femalePrayingMantis.Species + ":");
            femalePrayingMantis.Behavior.DoWhatAMantisWouldDo();

            femalePrayingMantis.ChangeBehavior(new DeffensiveBehavior());

            Console.WriteLine("\n~~~~~\nDeffensive behavior of a female " + femalePrayingMantis.Species + ":");
            femalePrayingMantis.Behavior.DoWhatAMantisWouldDo();
        }
    }
}
