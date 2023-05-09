using System.Text.Json;
using Api.Models;
using Api.Services;

namespace Api;

public class ItemLoader
{
    public static void LoadItems(IItemService itemService, string itemsInputPath)
    {
        var fileContent = File.ReadAllText(itemsInputPath);
        var itemList = JsonSerializer.Deserialize<List<CreateItemInput>>(fileContent, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});

        if (itemList == null)
            throw new InvalidOperationException("Unable to load items input file");

        foreach (var item in itemList)
        {
            itemService.AddItem(item);
        }
    }
}