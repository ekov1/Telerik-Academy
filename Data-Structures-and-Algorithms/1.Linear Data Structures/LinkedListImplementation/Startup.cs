namespace LinkedListImplementation
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            var list = new LinkedList<string>();

            var mouseLink = new ListItem<string>("Мишлето");

            list.FirstItem = mouseLink;

            var catLink = new ListItem<string>("Писанка");

            mouseLink.NextItem = catLink;

            var dogLink = new ListItem<string>("Шаро");

            catLink.NextItem = dogLink;

            var grandchildLink = new ListItem<string>("Внучката");

            dogLink.NextItem = grandchildLink;

            var nanaLink = new ListItem<string>("Бабата");

            grandchildLink.NextItem = nanaLink;

            var papaLink = new ListItem<string>("Дядото");

            nanaLink.NextItem = papaLink;

            var largeTurnip = new ListItem<string>("РЯПАТА >>(((()))");

            papaLink.NextItem = largeTurnip;

            foreach (var link in list)
            {
                Console.Write("{0} -> ", link);
            }

            Console.WriteLine();
        }
    }
}
