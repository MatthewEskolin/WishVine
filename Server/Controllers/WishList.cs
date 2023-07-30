using System;
using WishVine.Shared;

namespace WishVine.Server.Controllers;

public class WishList
{
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

        list.Items.Add(WishListItem.GetTestItem());
        list.Items.Add(WishListItem.GetTestItem());
        list.Items.Add(WishListItem.GetTestItem());
        list.Items.Add(WishListItem.GetTestItem());
        list.Items.Add(WishListItem.GetTestItem());

        return list;

    }


}

public class WishListItem
{
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string ImageLink { get; set; } = string.Empty;

    private static readonly Random Random = new();


    public static WishListItem GetTestItem()
    {
        var testItem = new WishListItem
        {
            Description = $"DESC-{GenerateRandomWord()}"
        };

        return new WishListItem();
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