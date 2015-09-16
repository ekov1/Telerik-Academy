namespace Facade
{
    public class PastryChefFacade
    {
        private PastryChef chef;
        private AssistantChef assistant;

        public PastryChefFacade(PastryChef chef, AssistantChef assistant)
        {
            this.chef = chef;
            this.assistant = assistant;
        }

        public void PrepareCake()
        {
            chef.BeatEggs();
            assistant.PourBeatenEggsInAnotherBowl();
            chef.WhipCream();
            chef.AddBakingPowder();
            chef.AddFlour();
            chef.AddButter();
            chef.AddSugar();
            chef.MixIngredients();
        }

        public void BakeCake()
        {
            assistant.PrepareCakePan();
            chef.PourInCakePan();
            chef.Bake();
            chef.PullOutOfOven();
        }

        public void ServeCake()
        {
            chef.CutCake();
            assistant.SampleCake();
            chef.ServeCake();
        }

        public void CleanUp()
        {
            chef.CleanCookingUtensils();
            chef.CleanCountertop();
            chef.SweepFloor();
        }
    }
}
