namespace Strategy
{
    using System;

    public class PassiveBehavior : IMantisBehavior
    {
        public void DoWhatAMantisWouldDo()
        {
            Console.WriteLine("You spread your wings and open your mouth in pitiful attempts to startle predators. \nIt's super effective!");
        }
    }
}