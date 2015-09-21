namespace Observer
{
    class Program
    {
        static void Main()
        {
            var fbPage = new FacebookPage("Parvata mi stranica <3");

            fbPage.AttachObserver(new PageSubscriber("Pesho"));
            fbPage.AttachObserver(new PageSubscriber("Misha"));

            fbPage.MakePost("Daite malko laikove, fen4itaa!");

            fbPage.MakePost("Vijte me i malkoto mi bratche kak tancuvame polo goli!1!1!");

            var anotherFbPage = new FacebookPage("BMW");
            anotherFbPage.AttachObserver(new PageSubscriber("Pesho"));

            anotherFbPage.MakePost("Check out the new BMW!");

            fbPage.MakePost("Vijti tas pesen na preslava, as pqh tam!");
        }
    }
}
