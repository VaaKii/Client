
using PublicAPI.v1.DTO.Interfaces;

namespace App.Public.DTO.v1;

public class DirectMessage : IEntity
{
    public Guid Id { get; set; }
    public Guid AppUserId { get; set; }
    public string? Message { get; set; }
	
    public Guid SenderId { get; set; }
}