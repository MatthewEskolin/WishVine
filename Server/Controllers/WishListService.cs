namespace WishVine.Server.Controllers;

public class WishListService
{
    public WishListService()
    {
    }

    public List<WishList> GetWishLists()
    {
        var list1 = WishList.NewListWithTestItems();
        var list2 = WishList.NewListWithTestItems();
        var list3 = WishList.NewListWithTestItems();

        var list = new List<WishList>
        {
            list1,
            list2,
            list3
        };

        return list;
    }
}