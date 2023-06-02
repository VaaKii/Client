using Logic.Base;
using Logic.Interfaces.Services;
using App.Public.DTO.v1;

namespace Logic.Services;

public class UserStoriesService : BaseService<UserStories, UserStories>, IUserStoriesService
{
  public UserStoriesService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }
}