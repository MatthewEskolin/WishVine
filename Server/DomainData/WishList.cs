using System.ComponentModel.DataAnnotations;

namespace WishVine.Server.DomainData;

public class WishList
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserDisplayName { get; set; } = string.Empty;
    public List<WishListItem> Items { get; set; } = new();

    public static WishList NewListWithTestItems()
    {
        var list = new WishList
        {
            Id = Guid.NewGuid()
        };

        list.AddItem(WishListItem.GetTestItem());
        list.AddItem(WishListItem.GetTestItem());
        list.AddItem(WishListItem.GetTestItem());
        list.AddItem(WishListItem.GetTestItem());
        list.AddItem(WishListItem.GetTestItem());
        list.AddItem(WishListItem.GetTestItem());

        return list;

    }

    private void AddItem(WishListItem item)
    {
        item.WishList = this;
        Items.Add(item);
    }


}