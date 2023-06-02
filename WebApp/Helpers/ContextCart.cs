using Extensions.Base;
using PublicAPI.v1.DTO.Interfaces;
using WebApp.Helpers.Interfaces;

namespace WebApp.Helpers;

public class ContextCart<TEntity>
  : ICart<TEntity>
  where TEntity : IEquatable<TEntity>
{
  private readonly HttpContext _context;
  private readonly string _name;

  public ContextCart(HttpContext context, string name = $"{nameof(TEntity)}_cart")
  {
    _context = context;
    _name = name;
  }

  public ICollection<TEntity> GetAll()
  {
    return _context.Session.GetJson<ICollection<TEntity>>(_name) ?? new List<TEntity>();
  }

  public void Add(TEntity entity)
  {
    var cart = GetAll();
    cart.Add(entity);
    _context.Session.SetJson(_name, cart);
  }

  public void Remove(TEntity entity)
  {
    var cart = GetAll();
    cart.Remove(entity);
    _context.Session.SetJson(_name, cart);
  }

  public void Clear()
  {
    _context.Session.SetJson(_name, new List<Guid>());
  }
}