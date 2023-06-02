using Logic.Base;
using Logic.Interfaces.Services;
using App.Public.DTO.v1;

namespace Logic.Services;

public class UserPostService : BaseService<UserPost, UserPost>, IUserPostService
{
  public UserPostService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }
}