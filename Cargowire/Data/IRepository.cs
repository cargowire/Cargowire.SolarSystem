using System;

namespace Cargowire.Data
{
    /// <summary>Identifies a repository as serving a particular entity type</summary>
    public interface IRepository<TEntity>
    {
        TEntity Get();
    }

    /// <summary>Identifies a repository as serving a particular entity type with a particular id type</summary>
    public interface IRepository<TEntity, TId>
    {
        System.Linq.IQueryable<TEntity> GetAll();
        TEntity Get(TId id);
        void Add(TEntity item);
        void Delete(TId id);
        void SaveChanges();
    }
}
