using System;

namespace Mediator
{
    class Program
    {
        static void Main()
        {
            var telerikTicketSystem = new TicketSystemMediator();

            var inexperiencedClient = new Client("Josh Duart", telerikTicketSystem);
            var kendoUiSupportTeam = new SupportTeam("KendoUI", telerikTicketSystem);

            telerikTicketSystem.Client = inexperiencedClient;
            telerikTicketSystem.SupportTeam = kendoUiSupportTeam;

            inexperiencedClient.SendTicketToMediator(new Ticket("jQuery doesn\'t load!!!1!", "I need help from you incompetent twats, your plugin supposedly works with jquery but doesnt come with it in a package and now I cant get my application running. Fix it!"));

            kendoUiSupportTeam.SendResponseToMediator(String.Format("Hello {0}, thank you for contacting us. \t<waaaay tooo much gibberish> ..... It's as simple as this to have Kendo UI up and running!", kendoUiSupportTeam.TicketSystem.Client.Name));


            Console.WriteLine("\n\n");


            var gratefulCustomer = new Client("Grateful Customer", telerikTicketSystem);++6
            telerikTicketSystem.Client = gratefulCustomer;

            gratefulCustomer.SendTicketToMediator(new Ticket("THANK YOU SO MUCH!", "I am only writing you to express my gratitude to the whole team that has helped me throughout the last few days! The problems are gone and now I can finally be productive once more! Thank you thank you thank you! Will make sure to bring cookies next time I visit Bulgaria!"));

            kendoUiSupportTeam.SendResponseToMediator("Hello, we are happy to learn that your ticket has been resolved. And do bring some cookies. We love cookies!");
        }
    }
}
