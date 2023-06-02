using App.Public.DTO.v1;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PublicAPI.v1.DTO;

namespace WebApp.Controllers;

public class DirectMessageController : Controller
{
  private readonly ILogger<DirectMessageController> _logger;
  private readonly IAppServiceStore _store;

  public DirectMessageController(ILogger<DirectMessageController> logger, IAppServiceStore store)
  {
    _logger = logger;
    _store = store;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<DirectMessage>>> GetAll()
  {
    return Ok(await _store.DirectMessages.GetAllAsync());
  }

  [HttpGet("{id:guid}")]
  public async Task<ActionResult<DirectMessage>> Get(Guid id)
  {
    var item = await _store.DirectMessages.FirstOrDefaultAsync(id);
    if (item == null)
      return NotFound();

    return Ok(item);
  }

  [HttpPost]
  public async Task<ActionResult<DirectMessage>> Post(DirectMessage item)
  {
    var addedItem = _store.DirectMessages.AddAsync(item);
    return CreatedAtAction(nameof(Get), new {id = addedItem.Id}, item);
  }

  [HttpPut("{id:guid}")]
  public async Task<IActionResult> Put(Guid id, DirectMessage item)
  {
    if (await _store.DirectMessages.FirstOrDefaultAsync(id) == null)
      return NotFound();

    await _store.DirectMessages.UpdateAsync(id, item);
    return NoContent();
  }

  [HttpDelete("{id:guid}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    if (await _store.DirectMessages.FirstOrDefaultAsync(id) == null)
      return NotFound();

    await _store.DirectMessages.DeleteAsync(id);
    return NoContent();
  }
}