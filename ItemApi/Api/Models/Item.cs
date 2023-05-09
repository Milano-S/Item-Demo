namespace Api.Models;

public class Item
{
    public Guid Key { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Condition { get; set; }
    public string PhotoUrl { get; set; }
    public ItemStatus Status { get; set; }

    public Item(Guid key, string name, string description, string Condition, string photoUrl)
    {
        Key = key;
        Title = name;
        Description = description;
        this.Condition = Condition;
        PhotoUrl = photoUrl;
        Status = ItemStatus.Available;
    }
}