namespace Strategy
{
    public class Mantis : IMantodea
    {
        public Mantis(string species, IMantisBehavior behavior)
        {
            this.Species = species;
            this.Behavior = behavior;
        }

        public string Species { get; private set; }
        public IMantisBehavior Behavior { get; private set; }

        public void ChangeBehavior(IMantisBehavior newBehavior)
        {
            this.Behavior = newBehavior;
        }
    }
}
