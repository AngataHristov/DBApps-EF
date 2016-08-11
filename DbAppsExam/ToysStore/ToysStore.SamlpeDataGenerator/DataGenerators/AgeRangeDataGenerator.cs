namespace ToysStore.SamlpeDataGenerator.DataGenerators
{
    using System;

    using Data;
    using Interfaces;
    using RandomDataGenerators;
    using System.Collections.Generic;

    public class AgeRangeDataGenerator : DataGenerator, IDataGenerator
    {
        public AgeRangeDataGenerator(IRandomDataGenerator random, ToysStoreEntities db, ILogger logger, int count)
            : base(random, db, logger, count)
        {
        }

        public override void Generate()
        {
            this.Logger.LogLine("Adding age ranges...");

            var ageRanges = new List<AgeRanx>();
            int count = new int();

            for (int i = 0; i < this.Count / 5; i++)
            {
                for (int j = i + 1; j < i + 5; j++)
                {
                    var ageRange = new AgeRanx()
                    {
                        MinimumAge = i,
                        MaximumAge = j
                    };

                    this.Db.AgeRanges.Add(ageRange);
                    count++;

                    if (count % 100 == 0)
                    {
                        this.Logger.Log(".");
                        this.Db.SaveChanges();
                    }

                    if (count == this.Count)
                    {
                        this.Logger.LogLine("\nAgeRanges added!");

                        return;
                    }
                }
            }
        }
    }
}
