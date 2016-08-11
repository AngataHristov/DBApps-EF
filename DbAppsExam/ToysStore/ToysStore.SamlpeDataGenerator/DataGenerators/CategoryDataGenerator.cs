
namespace ToysStore.SamlpeDataGenerator.DataGenerators
{
    using System;

    using Interfaces;
    using Data;
    using RandomDataGenerators;

    public class CategoryDataGenerator : DataGenerator, IDataGenerator
    {
        public CategoryDataGenerator(IRandomDataGenerator random, ToysStoreEntities db, ILogger logger, int count)
            : base(random, db, logger, count)
        {
        }

        public override void Generate()
        {
            this.Logger.LogLine("Adding categories...");

            for (int i = 0; i < this.Count; i++)
            {
                var category = new Category()
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 20)
                };

                this.Db.Categories.Add(category);

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.Db.SaveChanges();
                }
            }

            this.Logger.LogLine("\nCategories added!");
        }
    }
}
