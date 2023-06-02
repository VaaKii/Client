using Logic.Base;
using Logic.Interfaces;
using Logic.Interfaces.Services;
using Logic.Services;

namespace Logic;

public class AppServiceStore : BaseServiceStore, IAppServiceStore
{
  private readonly IHttpClientFactory _clientFactory;

  public AppServiceStore(IHttpClientFactory clientFactory)
  {
    _clientFactory = clientFactory;
  }

  public IDirectMessageService DirectMessages => GetService(() => new DirectMessageService(_clientFactory));
  public IFollowService Follows => GetService(() => new FollowService(_clientFactory));
  public ITopicService Topics => GetService(() => new TopicService(_clientFactory));
  public IUserCommentService UserComments => GetService(() => new UserUserCommentService(_clientFactory));
  public IUserHashtagService UserHashtags => GetService(() => new UserHashtagService(_clientFactory));
  public IUserLikeService UserLikes => GetService(() => new UserLikeService(_clientFactory));
  public IUserPostService UserPosts => GetService(() => new UserPostService(_clientFactory));
  public IUserStoriesService UserStories => GetService(() => new UserStoriesService(_clientFactory));
}