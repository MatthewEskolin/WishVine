using WishVine.Server.Data;
using WishVine.Server.DomainData;

public class SeedData
{
    public static void SeedDatabase(IServiceProvider provider)
    {
        var scope = provider.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<WishVineDbContext>();

        context.Database.EnsureCreated();

        if (!context.WishLists.Any())
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

            context.WishLists.AddRange(list);
            context.SaveChanges();

        }
    }
}