using System;
using System.Linq;

namespace Cargowire.Data
{
    /// <summary>Identifies a repository as serving a particular entity type</summary>
	public interface IRepository<TEntity> : IQueryable<TEntity>
    {
        TEntity Get();
    }

    /// <summary>Identifies a repository as serving a particular entity type with a particular id type</summary>
    public interface IRepository<TEntity, TId> : IQueryable<TEntity>
    {
        TEntity Get(TId id);
        void Add(TEntity item);
        void Delete(TId id);
        void SaveChanges();
    }
}
