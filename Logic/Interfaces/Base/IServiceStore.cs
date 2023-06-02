namespace Logic.Interfaces.Base;

public interface IServiceStore
{
  TService GetService<TService>(Func<TService> serviceCreationMethod)
    where TService : class;
}