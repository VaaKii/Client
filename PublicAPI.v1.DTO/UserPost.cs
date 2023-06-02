
using PublicAPI.v1.DTO.Interfaces;

namespace App.Public.DTO.v1;

public class UserPost : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Text { get; set; } = default!;

    public Guid TopicId { get; set; }
    public Topic? Topic { get; set; }
    public string? UrlPhoto { get; set; }
    public Guid AppUserId { get; set; }

    public ICollection<UserComment>? UserComments { get; set; }
    public ICollection<UserHashtag>? UserHashtags { get; set; }
    public ICollection<UserLike>? UserLikes { get; set; }

}