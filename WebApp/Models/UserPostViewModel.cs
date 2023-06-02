using App.Public.DTO.v1;
using Microsoft.AspNetCore.Mvc.Rendering;
using PublicAPI.v1.DTO;
using WebApp.Helpers;

namespace WebApp.Models;

public class UserPostViewModel
{
    public PaginatedList<UserPost> Posts { get; set; } = default!;

}