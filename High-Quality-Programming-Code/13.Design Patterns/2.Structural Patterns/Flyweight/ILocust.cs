namespace Flyweight
{
    public interface ILocust
    {
        string Size { get; }

        string Species { get; }

        Continent Continent { get; }

        string ChitinColor { get; }

        void Infest();
    }
}
