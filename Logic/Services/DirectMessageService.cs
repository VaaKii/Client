using App.Public.DTO.v1;
using Logic.Base;
using Logic.Interfaces.Services;
using PublicAPI.v1.DTO;

namespace Logic.Services;

public class DirectMessageService : BaseService<DirectMessage,DirectMessage>, IDirectMessageService
{
  public DirectMessageService(IHttpClientFactory clientFactory) : base(clientFactory)
  {
  }
}