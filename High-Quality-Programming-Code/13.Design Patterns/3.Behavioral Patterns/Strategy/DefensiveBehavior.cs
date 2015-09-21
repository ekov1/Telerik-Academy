namespace Strategy
{
    using System;

    public class DeffensiveBehavior : IMantisBehavior
    {
        public void DoWhatAMantisWouldDo()
        {
            Console.WriteLine("You try to mimic an ant. Surprisingly you succeed. The predators will now avoid you. \nNobody likes ants...");
        }
    }
}