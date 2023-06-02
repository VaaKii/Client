using Logic.Base;
using Logic.Interfaces.Services;
using App.Public.DTO.v1;

namespace Logic.Services;

public class TopicService : BaseService<Topic, Topic>, ITopicService
{
  public TopicService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }
}