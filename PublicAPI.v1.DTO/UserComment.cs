
using PublicAPI.v1.DTO.Interfaces;

namespace App.Public.DTO.v1;

public class UserComment : IEntity
{
    public Guid Id { get; set; }
    public string CommentText { get; set; } = default!;

    public Guid UserPostId { get; set; }
    // public UserPost? UserPost { get; set; }
    
    public Guid AppUserId { get; set; }
}