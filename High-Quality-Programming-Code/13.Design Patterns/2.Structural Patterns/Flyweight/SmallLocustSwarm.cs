namespace Flyweight
{
    using System;

    public class SmallLocustSwarm : ILocust
    {
        public SmallLocustSwarm(string color)
        {
            this.Size = "Small";
            this.Species = "Oversized Grasshoppers";
            this.Continent = Continent.Europe;

            this.ChitinColor = color;
        }

        public string Size { get; set; }

        public string Species { get; set; }

        public Continent Continent { get; set; }

        public string ChitinColor { get; set; }

        public void Infest()
        {
            Console.WriteLine(this.ChitinColor + "-colored locust swarm infested " + this.Continent.ToString() + "!");
        }
    }
}
