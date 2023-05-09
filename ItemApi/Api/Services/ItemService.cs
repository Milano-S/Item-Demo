using Api.Models;

namespace Api.Services;

public class ItemService : IItemService
{
    private readonly Dictionary<Guid, Item> _items = new ();
    
    public Item? GetItemByKey(Guid key)
    {
        var item = GetItem(key);

        return item?.Status == ItemStatus.Available 
            ? item
            : null;
    }

    public IEnumerable<Item> GetItems()
    {
        var item = _items.Values.Where(x => x.Status == ItemStatus.Available).ToList();

        return item;
    }

    public Item AddItem(CreateItemInput input)
    {
        var key = Guid.NewGuid();
        var item = new Item(key, input.Name, input.Description, input.Breed, input.PhotoUrl);

        _items.Add(key, item);

        return item;
    }

    public Item? UpdateItem(UpdateItemInput input)
    {
        var item = GetItem(input.Key);

        if (item == null)
            return null;
        
        item.Title = input.Name;
        item.Description = input.Description;
        item.Condition = input.Breed;
        item.PhotoUrl = input.PhotoUrl;

        return item;
    }

    public Item? StatusItem(Guid key)
    {
        var item = GetItem(key);

        if (item == null)
            return null;

        item.Status = ItemStatus.Available;

        return item;
    }

    private Item GetItem(Guid key)
    {
        var exists = _items.TryGetValue(key, out var item);

        if (!exists || item == null)
            return item;
        return item;
    }
}