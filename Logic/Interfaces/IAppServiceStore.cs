using Logic.Interfaces.Base;
using Logic.Interfaces.Services;

namespace Logic.Interfaces;

public interface IAppServiceStore : IServiceStore
{
  IDirectMessageService DirectMessages { get; }
  IFollowService Follows { get; }
  ITopicService Topics { get; }
  IUserCommentService UserComments { get; }
  IUserHashtagService UserHashtags { get; }
  IUserLikeService UserLikes { get; }
  IUserStoriesService UserStories { get; }
  IUserPostService UserPosts { get; }
}