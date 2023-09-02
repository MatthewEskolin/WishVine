namespace WishVine.Shared;

/// <summary>
/// DTO or Business Entity? don't know
/// </summary>
public class WishListDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string UserDisplayName { get; set; } = null!;

    public List<WishListItemDTO> Items { get; set; } = new();
    public string Description { get; set; } = null!;
    public int ItemCount { get; set; }
    public bool NewItems { get; set; }
}