namespace CarsSystem.ConsoleClient
{
    using CarsSystem.Data;

    public class Startup
    {
        public static void Main()
        {
            var context = new CarsSystemDbContext();

            JSonClassImporter.Import();
        }
    }
}
