using System;
using WishVine.Shared;

namespace WishVine.Server.Controllers;

public class WishList
{
    public string Name { get; set; } = string.Empty;
    public string UserDisplayName { get; set; } = string.Empty;
    public List<WishListItem> Items { get; set; } = new();

    public static WishList NewListWithTestItems()
    {
        var list = new WishList();
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
    public string Description { get; set; }
    public string Link { get; set; }
    public string ImageLink { get; set; }

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