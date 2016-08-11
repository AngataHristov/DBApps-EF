namespace ToysStore.SamlpeDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Interfaces;
    using RandomDataGenerators;

    public class ToyDataGenerator : DataGenerator
    {
        public ToyDataGenerator(IRandomDataGenerator random, ToysStoreEntities db, ILogger logger, int count)
            : base(random, db, logger, count)
        {
        }

        public override void Generate()
        {
            this.Logger.LogLine("Adding toys...");

            var ageRangeIds = this.Db.AgeRanges
                .Select(a => a.Id)
                .ToList();

            var manufacturerIds = this.Db.Manufacturers
                .Select(m => m.Id)
                .ToList();

            var categoryIds = this.Db.Categories
                .Select(c => c.Id)
                .ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var toy = new Toy()
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Type = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Price = this.Random.GetRandomNumber(10, 500),
                    Color = this.Random.GetRandomNumber(1, 5) == 5 ?
                    null : this.Random.GetRandomStringWithRandomLength(3, 20),
                    ManufacturerId = manufacturerIds[this.Random.GetRandomNumber(0, manufacturerIds.Count - 1)],
                    AgeRangeId = ageRangeIds[this.Random.GetRandomNumber(0, ageRangeIds.Count - 1)]
                };

                var uniqueCategoryIds = new HashSet<int>();

                if (categoryIds.Count > 0)
                {
                    var categoriesInToy = this.Random.GetRandomNumber(1, 10);

                    while (uniqueCategoryIds.Count != categoriesInToy)
                    {
                        uniqueCategoryIds.Add(categoryIds[this.Random.GetRandomNumber(0, categoryIds.Count - 1)]);
                    }
                }

                foreach (var categoryId in uniqueCategoryIds)
                {
                    toy.Categories.Add(this.Db.Categories.Find(categoryId));
                }

                this.Db.Toys.Add(toy);

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.Db.SaveChanges();
                }
            }

            this.Logger.LogLine("\nToys added!");
        }
    }
}
