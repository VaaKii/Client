namespace WebApp.Helpers.Interfaces;

public interface ICart<TEntity>
  where TEntity : IEquatable<TEntity>
{
  ICollection<TEntity> GetAll();
  void Add(TEntity entity);
  void Remove(TEntity entity);
  void Clear();
}