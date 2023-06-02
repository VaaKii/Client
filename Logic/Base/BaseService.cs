using System.Net.Http.Json;
using System.Xml;
using Logic.Interfaces.Base;
using PublicAPI.v1.DTO.Interfaces;

namespace Logic.Base;

public class BaseService
{
  protected readonly HttpClient Client;

  public BaseService(IHttpClientFactory clientFactory)
  {
    Client = clientFactory.CreateClient("BaseApi");
  }

  protected static string GetEndpoint(string path, string version = "1.0")
    => $"api/v{version}/{path}";
}

public class BaseService<TEntity, TAddEntity>
  : BaseService<TEntity, TAddEntity, Guid>
  where TEntity : IEntity<Guid>
{
  public BaseService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }
}

public class BaseService<TEntity, TAddEntity, TKey>
  : BaseService, IService<TEntity, TAddEntity, TKey>
  where TEntity : IEntity<TKey>
  where TKey : IEquatable<TKey>
{
  public BaseService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }

  public async Task<IEnumerable<TEntity>> GetAllAsync()
  {
    var endpoint = GetEndpoint($"{typeof(TEntity).Name}");
    try
    {
      var result = await Client.GetFromJsonAsync<IEnumerable<TEntity>>(endpoint);
      return result ?? new List<TEntity>();
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      return new List<TEntity>();
    }
  }

  public async Task<TEntity?> FirstOrDefaultAsync(TKey id)
  {
    var endpoint = GetEndpoint($"{typeof(TEntity).Name}/{id}");
    return await Client.GetFromJsonAsync<TEntity>(endpoint);
  }

  public async Task<TEntity?> AddAsync(TAddEntity entity)
  {
    var endpoint = GetEndpoint($"{typeof(TEntity).Name}");
    var response = await Client.PostAsJsonAsync(endpoint, entity);
    return await response.Content.ReadFromJsonAsync<TEntity>();
  }

  public async Task UpdateAsync(TKey id, TAddEntity entity)
  {
    var endpoint = GetEndpoint($"{typeof(TEntity).Name}/{id}");
    await Client.PutAsJsonAsync(endpoint, entity);
  }

  public async Task DeleteAsync(TKey id)
  {
    var endpoint = GetEndpoint($"{typeof(TEntity).Name}/{id}");
    await Client.DeleteAsync(endpoint);
  }
}