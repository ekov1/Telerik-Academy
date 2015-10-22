namespace Code_First_Cars_ConsoleClient.Models
{
    using System;

    public class CarJson
    {
        public int Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerJson Dealer { get; set; }
    }
}
