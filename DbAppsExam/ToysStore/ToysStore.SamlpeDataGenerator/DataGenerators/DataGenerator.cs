namespace ToysStore.SamlpeDataGenerator.DataGenerators
{
    using System;

    using Data;
    using Interfaces;
    using RandomDataGenerators;

    public abstract class DataGenerator : IDataGenerator
    {
        private readonly IRandomDataGenerator random;
        private readonly ToysStoreEntities db;
        private readonly ILogger logger;
        private int count;

        public DataGenerator(IRandomDataGenerator random, ToysStoreEntities db, ILogger logger, int count)
        {
            this.random = random;
            this.db = db;
            this.count = count;
            this.logger = logger;
        }

        public IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        public ToysStoreEntities Db
        {
            get { return this.db; }
        }

        public ILogger Logger
        {
            get { return this.logger; }
        }

        public int Count
        {
            get { return this.count; }
        }

        public abstract void Generate();
    }
}
