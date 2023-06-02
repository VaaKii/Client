using Logic.Base;
using Logic.Interfaces.Services;
using App.Public.DTO.v1;

namespace Logic.Services;

public class UserUserCommentService : BaseService<UserComment, UserComment>, IUserCommentService
{
  public UserUserCommentService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }
}