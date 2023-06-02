using App.Public.DTO.v1;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PublicAPI.v1.DTO;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Controllers;

public class UserPostController : Controller
{
    private readonly ILogger<UserPostController> _logger;
    private readonly IAppServiceStore _store;

    public UserPostController(ILogger<UserPostController> logger, IAppServiceStore store)
    {
        _logger = logger;
        _store = store;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserPost>>> GetAll()
    {
        return Ok(await _store.UserPosts.GetAllAsync());
    }

    public async Task<IActionResult> Index()
    {
        var posts = await _store.UserPosts.GetAllAsync();
        Console.WriteLine(posts.Count());
        var model = new UserPostViewModel
        {
            Posts = PaginatedList<UserPost>.Create(posts, 1, 10)
        };
        Console.WriteLine(model.Posts.Count);
        return View(model);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserPost>> Get(Guid id)
    {
        var item = await _store.UserPosts.FirstOrDefaultAsync(id);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<UserPost>> Post(UserPost item)
    {
        var addedItem = await _store.UserPosts.AddAsync(item);
        return CreatedAtAction(nameof(Get), new {id = addedItem?.Id}, item);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UserPost item)
    {
        if (await _store.UserPosts.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.UserPosts.UpdateAsync(id, item);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _store.UserPosts.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.UserPosts.DeleteAsync(id);
        return NoContent();
    }
}