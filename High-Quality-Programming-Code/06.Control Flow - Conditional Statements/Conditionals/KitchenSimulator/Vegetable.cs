namespace KitchenSimulator
{
    using System;

    public class Vegetable : IVegetable
    {
        public Vegetable()
        {
            this.IsPeeled = false;
            this.IsCut = false;
            this.IsRotten = false;
        }

        public bool IsRotten { get; private set; }

        public bool IsCut { get; private set; }

        public bool IsPeeled { get; private set; }

        public void Cut()
        {
            if (this.IsCut)
            {
                Console.WriteLine("The vegetable has already been cut!");
            }
            else
            {
                this.IsCut = true;
            }
        }

        public void Peel()
        {
            if (this.IsPeeled)
            {
                Console.WriteLine("The vegetable has already been peeled!");
            }
            else
            {
                this.IsPeeled = true;
            }
        }
    }
}
