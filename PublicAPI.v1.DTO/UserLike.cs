
using PublicAPI.v1.DTO.Interfaces;

namespace App.Public.DTO.v1;

public class UserLike : IEntity
{
    public Guid Id { get; set; }
    public Guid UserPostId { get; set; }
    public UserPost? UserPost { get; set; }

    public Guid AppUserId { get; set; }
}