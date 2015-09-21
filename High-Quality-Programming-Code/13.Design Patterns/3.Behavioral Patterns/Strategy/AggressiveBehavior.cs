namespace Strategy
{
    using System;
    
    public class AggressiveBehavior : IMantisBehavior
    {
        public void DoWhatAMantisWouldDo()
        {
            Console.WriteLine("Flail your raptorial legs up and down like crazy! - You are the embodiment of DEATH!");
        }
    }
}
