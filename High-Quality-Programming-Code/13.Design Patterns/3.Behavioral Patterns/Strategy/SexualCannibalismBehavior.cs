namespace Strategy
{
    using System;

    public class SexualCannibalismBehavior : IMantisBehavior
    {
        public void DoWhatAMantisWouldDo()
        {
            var rng = new Random();

            if (rng.Next(1, 100) == 69)
            {
                Console.WriteLine("Your mate survived the day, he will live to see another f...! \nThat lucky motherf...er...");
                return;
            }
            else
            {
                Console.WriteLine("You chop your mate's head off and munch it like it's the best thing you've ever had! \nIt actually feels better than the sex that you two just had!");
            }
        }
    }
}