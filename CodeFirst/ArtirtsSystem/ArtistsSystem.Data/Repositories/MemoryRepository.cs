namespace ArtistsSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Models;

    public class MemoryRepository<TEntity/*, TKey*/> : IRepository<TEntity>
       // where TEntity : IEntity<TKey>
    {
        private readonly ICollection<TEntity> data;

        public MemoryRepository()
        {
            this.data = new List<TEntity>();
        }

        public IQueryable<TEntity> All()
        {
            return this.data.AsQueryable();
        }

        public TEntity FindById(object id)
        {
            return this.data.FirstOrDefault();
        }

        public void Add(TEntity entity)
        {
            this.data.Add(entity);
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            this.data.Remove(entity);
        }

        public void SaveChanges()
        {
           
        }
    }
}
