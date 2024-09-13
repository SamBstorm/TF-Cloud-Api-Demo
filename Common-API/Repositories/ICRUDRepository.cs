using Common_API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common_API.Repositories
{
    public interface ICRUDRepository<TEntity, TId> where TEntity : IEntity
    {
        public IEnumerable<TEntity> Get();
        public TEntity Get(TId id);
        public TId Insert(TEntity entity);
        public void Update(TId id, TEntity entity);
        public void Delete(TId id);
    }
}
