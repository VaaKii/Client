using Logic.Interfaces.Base;

namespace Logic.Base;

public class BaseServiceStore : IServiceStore
{
  private readonly Dictionary<Type, object> _serviceCache = new();

  public TService GetService<TService>(Func<TService> serviceCreationMethod) where TService : class
  {
    if (_serviceCache.TryGetValue(typeof(TService), out var repo))
      return (TService)repo;

    var repoInstance = serviceCreationMethod();
    _serviceCache.Add(typeof(TService), repoInstance);
    return repoInstance;
  }
}