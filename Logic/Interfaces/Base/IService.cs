using PublicAPI.v1.DTO.Interfaces;

namespace Logic.Interfaces.Base;

public interface IService
{
}

public interface IService<TEntity, in TAddEntity>
  : IService<TEntity, TAddEntity, Guid>
  where TEntity : IEntity<Guid>
{
}

public interface IService<TEntity, in TAddEntity, in TKey>
  where TEntity : IEntity<TKey>
  where TKey : IEquatable<TKey>
{
  Task<IEnumerable<TEntity>> GetAllAsync();
  Task<TEntity?> FirstOrDefaultAsync(TKey id);
  Task<TEntity?> AddAsync(TAddEntity entity);
  Task UpdateAsync(TKey id, TAddEntity entity);
  Task DeleteAsync(TKey id);
}