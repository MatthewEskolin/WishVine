using Microsoft.EntityFrameworkCore;
using WishVine.Server.Data;
using WishVine.Server.DomainData;

namespace WishVine.Server.Services;

public class WishListService
{
    public WishListService(WishVineDbContext ctx)
    {
        Ctx = ctx;
    }

    private WishVineDbContext Ctx { get; set; }

    //method to save a new wish list to the database
    public async Task<WishList> SaveWishList(WishList list)
    {
        Ctx.WishLists.Add(list);
        await Ctx.SaveChangesAsync();
        return list;
    }

    //method to get wish lists from the database based on criteria
    public async Task<List<WishList>> GetWishLists()
    {
        return await Ctx.WishLists.ToListAsync();
    }

    public List<WishList> GetWishListsTest()
    {



        var list1 = TestWishList.NewListWithTestItems();
        list1.Name = "Matt's Wish List";

        var list2 = TestWishList.NewListWithTestItems();
        list2.Name = "Sara's Wish List";

        var list3 = TestWishList.NewListWithTestItems();
        list3.Name = "Tom's Wish List";

        var list = new List<WishList>
        {
            list1,
            list2,
            list3
        };

        return list;
    }

    public async Task<WishList> GetWishList(Guid id)
    {
        var list = await Ctx.WishLists.FirstAsync(x => x.Id == id);
        return list;

        //TODO add error handling for exception 
    }

    public async Task DeleteWishList(Guid id)
    {
        var list = await Ctx.WishLists.FirstAsync(x => x.Id == id);
        Ctx.WishLists.Remove(list);
        await Ctx.SaveChangesAsync();

    }
}