using Logic.Base;
using App.Public.DTO.v1;
using Logic.Interfaces.Services;

namespace Logic.Services;

public class UserHashtagService : BaseService<UserHashtag, UserHashtag>, IUserHashtagService
{
  public UserHashtagService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }
}