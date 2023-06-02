using App.Public.DTO.v1;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PublicAPI.v1.DTO;

namespace WebApp.Controllers;

public class FollowController : Controller
{
  private readonly ILogger<FollowController> _logger;
  private readonly IAppServiceStore _store;

  public FollowController(ILogger<FollowController> logger, IAppServiceStore store)
  {
    _logger = logger;
    _store = store;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Follow>>> GetAll()
  {
    return Ok(await _store.Follows.GetAllAsync());
  }

  [HttpGet("{id:guid}")]
  public async Task<ActionResult<Follow>> Get(Guid id)
  {
    var item = await _store.Follows.FirstOrDefaultAsync(id);
    if (item == null)
      return NotFound();

    return Ok(item);
  }

  [HttpPost]
  public async Task<ActionResult<Follow>> Post(Follow item)
  {
    var addedItem = await _store.Follows.AddAsync(item);
    return CreatedAtAction(nameof(Get), new {id = addedItem?.Id}, item);
  }

  [HttpPut("{id:guid}")]
  public async Task<IActionResult> Put(Guid id, Follow item)
  {
    if (await _store.Follows.FirstOrDefaultAsync(id) == null)
      return NotFound();

    await _store.Follows.UpdateAsync(id, item);
    return NoContent();
  }

  [HttpDelete("{id:guid}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    if (await _store.Follows.FirstOrDefaultAsync(id) == null)
      return NotFound();

    await _store.Follows.DeleteAsync(id);
    return NoContent();
  }
}