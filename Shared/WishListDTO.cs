namespace WishVine.Shared;

/// <summary>
/// DTO or Business Entity? don't know
/// </summary>
public class WishListDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserDisplayName { get; set; } = string.Empty;

    public List<WishListItemDTO> Items { get; set; } = new();

}