using Logic.Base;
using App.Public.DTO.v1;
using Logic.Interfaces.Services;

namespace Logic.Services;

public class FollowService : BaseService<Follow, Follow>, IFollowService
{
  public FollowService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }
}