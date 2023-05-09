using Api.Models;

namespace Api.Services;

public interface IItemService
{
    Item? GetItemByKey(Guid key);
    IEnumerable<Item> GetItems();
    Item AddItem(CreateItemInput input);
    Item? UpdateItem(UpdateItemInput input);
    Item? StatusItem(Guid key);
}