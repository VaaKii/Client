
using PublicAPI.v1.DTO.Interfaces;

namespace App.Public.DTO.v1;

public class UserHashtag : IEntity
{
    public Guid Id { get; set; }
    public string HashtagText { get; set; } = default!;
    public ICollection<UserPost>? Posts { get; set; }
}