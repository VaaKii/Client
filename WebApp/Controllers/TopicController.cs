using App.Public.DTO.v1;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PublicAPI.v1.DTO;

namespace WebApp.Controllers;

public class TopicController : Controller
{
    private readonly ILogger<TopicController> _logger;
    private readonly IAppServiceStore _store;

    public TopicController(ILogger<TopicController> logger, IAppServiceStore store)
    {
        _logger = logger;
        _store = store;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Topic>>> GetAll()
    {
        return Ok(await _store.Topics.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Topic>> Get(Guid id)
    {
        var item = await _store.Topics.FirstOrDefaultAsync(id);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<Topic>> Post(Topic item)
    {
        var addedItem = await _store.Topics.AddAsync(item);
        return CreatedAtAction(nameof(Get), new {id = addedItem?.Id}, item);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, Topic item)
    {
        if (await _store.Topics.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.Topics.UpdateAsync(id, item);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _store.Topics.FirstOrDefaultAsync(id) == null)
            return NotFound();

        await _store.Topics.DeleteAsync(id);
        return NoContent();
    }
}