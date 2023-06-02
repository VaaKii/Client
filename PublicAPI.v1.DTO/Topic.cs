
using PublicAPI.v1.DTO.Interfaces;

namespace App.Public.DTO.v1;

public class Topic : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public ICollection<UserPost>? UserPosts { get; set; }
}