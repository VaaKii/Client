using App.Public.DTO.v1;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PublicAPI.v1.DTO;

namespace WebApp.Controllers;

public class UserStoriesController : Controller
{
    private readonly ILogger<UserStoriesController> _logger;
    private readonly IAppServiceStore _store;

    public UserStoriesController(ILogger<UserStoriesController> logger, IAppServiceStore store)
    {
        _logger = logger;
        _store = store;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserStories>>> GetAll()
    {
        return Ok(await _store.UserStories.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserStories>> Get(Guid id)
    {
        var item = await _store.UserStories.FirstOrDefaultAsync(id);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<UserStories>> Post(UserStories item)
    {
        var addedItem = await _store.UserStories.AddAsync(item);
        return CreatedAtAction(nameof(Get), new {id = addedItem?.Id}, item);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UserStories item)
    {
        if (await _store.UserStories.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.UserStories.UpdateAsync(id, item);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _store.UserStories.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.UserStories.DeleteAsync(id);
        return NoContent();
    }
}