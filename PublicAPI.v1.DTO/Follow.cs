
using PublicAPI.v1.DTO.Interfaces;

namespace App.Public.DTO.v1;

public class Follow : IEntity 
{
    public Guid Id { get; set; }
    public Guid AppUserId { get; set; }
}