namespace Memento
{
    public interface ICharacter
    {
        string Name { get; set; }
        bool IsAlive { get; set; }

        void Kill(ICharacter target);
    }
}
