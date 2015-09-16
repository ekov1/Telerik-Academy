namespace Facade
{
    using System;
    using System.Threading;

    public class PastryChef
    {
        public void BeatEggs()
        {
            Console.WriteLine("Beating them eggs...");
        }

        public void WhipCream()
        {
            Console.WriteLine("Whipping dat cream tho...");
        }

        public void AddSugar()
        {
            Console.WriteLine("Adding half a cup 'o sugar...");
        }

        public void AddFlour()
        {
            Console.WriteLine("Adding flour...");
        }

        public void AddBakingPowder()
        {
            Console.WriteLine("Adding a spoonful of baking powder...");
        }

        public void AddButter()
        {
            Console.WriteLine("Adding a block of the best butter there is...");
        }

        public void MixIngredients()
        {
            Console.WriteLine("Mixing all the crap that we now have in the bowl !1!1!1!!!!");
        }

        public void PourInCakePan()
        {
            Console.WriteLine("Pouring mixture into the pan... in...");
            Console.WriteLine("3");
            Thread.Sleep(1000);
            Console.WriteLine("2");
            Thread.Sleep(1000);
            Console.WriteLine("1");
        }

        public void Bake()
        {
            Console.WriteLine("Cake's being baked, be ready in a second!");
            Thread.Sleep(1500);
            Console.WriteLine("Cake's baked!");
        }

        public void PullOutOfOven()
        {
            Console.WriteLine("Pulling cake out of the oven.");
        }

        public void CutCake()
        {
            Console.WriteLine("Cutting cake into uneven pieces. Soz, knife's not sharp...");
        }

        public void ServeCake()
        {
            Console.WriteLine("Serving cake to the your frie.... to yourself, you have no friends after all...");
        }

        public void CleanCookingUtensils()
        {
            Console.WriteLine("Washing up cooking utensils.");
        }

        public void CleanCountertop()
        {
            Console.WriteLine("Cleaning up the counter top...");
        }

        public void SweepFloor()
        {
            Console.WriteLine("Sweeping the kitchen floors of all the mess that you made!");
        }
    }
}
