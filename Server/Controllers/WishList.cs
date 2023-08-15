using System;
using System.ComponentModel.DataAnnotations;
using WishVine.Shared;

namespace WishVine.Server.Controllers;

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

public class WishListItem
{
    [Key]
    public int WishListItemId { get; set; }
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string ImageLink { get; set; } = string.Empty;
    public WishList WishList { get; set; }

    private static readonly Random Random = new();

    //changes in dev branch 3

    //changes in dev branch 4

    //changes in dev branch 6

    public static WishListItem GetTestItem()
    {
        var testItem = new WishListItem
        {
            Description = $"DESC-{GenerateRandomWord()}",
            Link = $"LINK-{GenerateRandomWord()}",
            ImageLink = $"IMAGE-{GenerateRandomWord()}",
        };

        return testItem;
    }

    private static string GenerateRandomWord()
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        var wordArray = new char[5];

        for (var i = 0; i < 5; i++)
        {
            var randomIndex = Random.Next(0, alphabet.Length);
            wordArray[i] = alphabet[randomIndex];
        }

        return new string(wordArray);
    }

}