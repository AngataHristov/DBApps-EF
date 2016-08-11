namespace ToysStore.SamlpeDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Data;
    using RandomDataGenerators;

    public class ManufacturerDataGenerator : DataGenerator, IDataGenerator
    {
        public ManufacturerDataGenerator(IRandomDataGenerator random, ToysStoreEntities db, ILogger logger, int count)
            : base(random, db, logger, count)
        {
        }

        public override void Generate()
        {

            var manufacturerToAdded = new HashSet<string>();

            while (manufacturerToAdded.Count != this.Count)
            {
                string name = this.Random.GetRandomStringWithRandomLength(5, 20);
                manufacturerToAdded.Add(name);
            }

            this.Logger.LogLine("Adding manufacturers...");
            int index = 0;

            foreach (string manufact in manufacturerToAdded)
            {
                var manufacturer = new Manufacturer()
                {
                    Name = manufact,
                    Country = this.Random.GetRandomStringWithRandomLength(2, 100)
                };

                this.Db.Manufacturers.Add(manufacturer);

                if (index % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.Db.SaveChanges();
                }

                index++;
            }

            this.Logger.LogLine("\nManufacturers added!");
        }
    }
}
