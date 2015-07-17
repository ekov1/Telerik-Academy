namespace KitchenSimulator
{
    using System;
    using System.Collections.Generic;

    public class Bowl
    {
        public Bowl()
        {
            this.Ingredients = new List<Vegetable>();
        }

        public List<Vegetable> Ingredients { get; private set; }

        public void Add(Vegetable veggie)
        {
            if (veggie == null)
            {
                throw new ArgumentNullException();
            }

            if (!veggie.IsCut || !veggie.IsPeeled)
            {
                Console.WriteLine("Vegetable must be peeled and cut before being added to the bowl!");
            }
            else
            {
                this.Ingredients.Add(veggie);
            }
        }
    }
}
