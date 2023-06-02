using App.Public.DTO.v1;
using PublicAPI.v1.DTO.Interfaces;

namespace PublicAPI.v1.DTO.Identity;

public class Account : IEntity
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
  
  public UserPost UserPosts { get; set; } = default!;
  public Guid Id { get; set; }
}

public class LoginRequest
{
  public string Email { get; set; } = default!;
  public string Password { get; set; } = default!;
}

public class RegisterRequest
{
  public string Email { get; set; } = default!;
  public string Password { get; set; } = default!;
  public string ConfirmPassword { get; set; } = default!;
}