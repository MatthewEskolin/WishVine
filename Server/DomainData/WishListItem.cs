using System.ComponentModel.DataAnnotations;

namespace WishVine.Server.DomainData;

public class WishListItem
{
    [Key]
    public int WishListItemId { get; set; }
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string ImageLink { get; set; } = string.Empty;
    public WishList WishList { get; set; } = null!;

    private static readonly Random Random = new();

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

    //try git alias

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