namespace ToysStore.SamlpeDataGenerator
{
    using System.Collections.Generic;

    using Interfaces;
    using Data;
    using RandomDataGenerators;
    using DataGenerators;

    public class Startup
    {
        public static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new ToysStoreEntities();
            var logger = new Logger();

            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>()
            {
                new CategoryDataGenerator(random,db,logger,100),
                new ManufacturerDataGenerator(random,db,logger,50),
                new AgeRangeDataGenerator(random,db,logger,100),
                new ToyDataGenerator(random,db,logger,20000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
