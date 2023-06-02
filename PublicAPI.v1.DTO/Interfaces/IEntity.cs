namespace PublicAPI.v1.DTO.Interfaces;

public interface IEntity
  : IEntity<Guid>
{
}

public interface IEntity<TKey>
  where TKey : IEquatable<TKey>
{
  TKey Id { get; set; }
}