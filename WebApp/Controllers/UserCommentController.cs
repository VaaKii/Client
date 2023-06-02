using App.Public.DTO.v1;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PublicAPI.v1.DTO;

namespace WebApp.Controllers;

public class UserCommentController : Controller
{
    private readonly ILogger<UserCommentController> _logger;
    private readonly IAppServiceStore _store;

    public UserCommentController(ILogger<UserCommentController> logger, IAppServiceStore store)
    {
        _logger = logger;
        _store = store;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserComment>>> GetAll()
    {
        return Ok(await _store.UserComments.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserComment>> Get(Guid id)
    {
        var item = await _store.UserComments.FirstOrDefaultAsync(id);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<UserComment>> Post(UserComment item)
    {
        var addedItem = await _store.UserComments.AddAsync(item);
        return CreatedAtAction(nameof(Get), new {id = addedItem?.Id}, item);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UserComment item)
    {
        if (await _store.UserComments.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.UserComments.UpdateAsync(id, item);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _store.UserComments.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.UserComments.DeleteAsync(id);
        return NoContent();
    }
}