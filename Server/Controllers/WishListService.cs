using WishVine.Server.Data;

namespace WishVine.Server.Controllers;

public class WishListService
{
    public WishListService(WishVineDbContext ctx)
    {
        Ctx = ctx;
    }

    private WishVineDbContext Ctx { get; set; }

    public List<WishList> GetWishLists()
    {
        var list1 = WishList.NewListWithTestItems();
        list1.Name = "Matt's Wish List";



        var list2 = WishList.NewListWithTestItems();
        list2.Name = "Sara's Wish List";

        var list3 = WishList.NewListWithTestItems();
        list3.Name = "Tom's Wish List";

        var list = new List<WishList>
        {
            list1,
            list2,
            list3
        };

        return list;
    }

    public WishList GetWishList(Guid id)
    {

        var list1 = WishList.NewListWithTestItems();
        list1.Name = "Matt's Wish List";

        return list1;
    }
}