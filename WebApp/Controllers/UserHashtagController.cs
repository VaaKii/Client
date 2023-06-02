using App.Public.DTO.v1;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PublicAPI.v1.DTO;

namespace WebApp.Controllers;

public class UserHashtagController : Controller
{
    private readonly ILogger<UserHashtagController> _logger;
    private readonly IAppServiceStore _store;

    public UserHashtagController(ILogger<UserHashtagController> logger, IAppServiceStore store)
    {
        _logger = logger;
        _store = store;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserHashtag>>> GetAll()
    {
        return Ok(await _store.UserHashtags.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserHashtag>> Get(Guid id)
    {
        var item = await _store.UserHashtags.FirstOrDefaultAsync(id);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<UserHashtag>> Post(UserHashtag item)
    {
        var addedItem = await _store.UserHashtags.AddAsync(item);
        return CreatedAtAction(nameof(Get), new {id = addedItem?.Id}, item);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UserHashtag item)
    {
        if (await _store.UserHashtags.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.UserHashtags.UpdateAsync(id, item);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _store.UserHashtags.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.UserHashtags.DeleteAsync(id);
        return NoContent();
    }
}