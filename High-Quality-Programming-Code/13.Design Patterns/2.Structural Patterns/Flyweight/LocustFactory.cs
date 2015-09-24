namespace Flyweight
{
    using System.Collections.Generic;

    public class LocustFactory
    {
        private readonly Dictionary<string, ILocust> list = new Dictionary<string, ILocust>();

        public int NumberOfEntries()
        {
            return this.list.Count;
        }

        public ILocust GetLocust(string color)
        {
            if (this.list.ContainsKey(color))
            {
                return this.list[color];
            }
            
            var locust = new SmallLocustSwarm(color);

            list.Add(color, locust);

            return locust;
        }
    }
}
