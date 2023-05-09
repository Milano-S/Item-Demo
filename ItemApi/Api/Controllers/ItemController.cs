using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    [Route("{key:Guid}")]
    public IActionResult GetItem(Guid key)
    {
        var item = _itemService.GetItemByKey(key);

        return item != null
            ? Ok(item)
            : NotFound();
    }

    [HttpGet]
    public IActionResult GetItems()
    {
        var items = _itemService.GetItems();
        HttpContext.Response.Headers.Add("CustomHeader", DateTime.UtcNow.ToString());

        return Ok(items);
    }

    [HttpPost]
    public IActionResult AddItem(CreateItemInput input)
    {
        var newItem = _itemService.AddItem(input);

        return Created("", newItem);
    }

    [HttpPut]
    public IActionResult UpdatePuppy(UpdateItemInput input)
    {
        var updatedPuppy = _itemService.UpdateItem(input);

        return updatedPuppy != null
            ? Ok(updatedPuppy)
            : NotFound();
    }

    /*[HttpPost]
    [Route("status/{key:Guid}")]
    public IActionResult AdoptPuppy(Guid key)
    {
        var puppy = _itemService.StatusItem(key);

        return puppy != null
            ? Ok(puppy)
            : NotFound();
    }*/
}