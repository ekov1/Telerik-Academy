namespace _03.AnimalHierarchy
{
    class Tomcat : Cat, ISound
    {
        public Tomcat(int age, string name)
            :base(age, name)
        {
            this.Sex = sex.male;
        }
    }
}
