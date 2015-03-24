namespace _03.AnimalHierarchy
{
    class Kitten: Cat, ISound
    {
        public Kitten(int age, string name)
            :base(age, name)
        {
            this.Sex = sex.female;
        }
    }
}
