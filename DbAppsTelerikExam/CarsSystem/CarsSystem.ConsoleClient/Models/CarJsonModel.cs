namespace CarsSystem.ConsoleClient.Models
{
    public class CarJsonModel
    {
        public ushort Year { get; set; }

        public int TransmitionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerJsonModel Dealer { get; set; }
    }
}
