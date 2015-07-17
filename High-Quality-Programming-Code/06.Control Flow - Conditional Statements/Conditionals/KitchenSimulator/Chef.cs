namespace KitchenSimulator
{
    using System;
    using System.Collections.Generic;

    public class Chef
    {
        public Bowl Cook(IList<Vegetable> vegetables)
        {
            Bowl cookingBowl = new Bowl();

            foreach (var veggie in vegetables)
            {
                cookingBowl.Add(veggie);
            }

            return cookingBowl;
        }

        public Bowl Cook(Vegetable veggie)
        {
            Bowl cookingBowl = new Bowl();

            if (veggie != null)
            {
                cookingBowl.Add(veggie);

                if (cookingBowl.Ingredients.Count == 0)
                {
                    Console.WriteLine("Your attempt at cooking the vegetable was a big failure, vegetables must be peeled, cut and fresh!");
                    return cookingBowl;
                }
                else
                {
                    return cookingBowl;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void CookTest()
        {
            // Base code refactored functionally goes below
            Potato potato = new Potato();
            Carrot carrot = new Carrot();
            Bowl bowl = new Bowl();

            potato.Peel();
            carrot.Peel();
            potato.Cut();
            carrot.Cut();

            bowl.Add(carrot);
            bowl.Add(potato);

            // task2 - Potato COOKING! - included in the base code
            this.Cook(bowl.Ingredients);
        }
    }
}
