using Logic.Base;
using Logic.Interfaces.Services;
using App.Public.DTO.v1;

namespace Logic.Services;

public class UserLikeService : BaseService<UserLike, UserLike>, IUserLikeService
{
  public UserLikeService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }
}