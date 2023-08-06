using Microsoft.EntityFrameworkCore;
using WishVine.Server.Controllers;

namespace WishVine.Server.Data;

public class WishVineDbContext:DbContext
{
    public WishVineDbContext(DbContextOptions<WishVineDbContext> options) : base(options)
    {
    }

    public DbSet<WishList> WishLists { get; set; } = null!;
    public DbSet<WishListItem> WishListItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WishList>().HasMany(x => x.Items).WithOne(x => x.WishList);
    }
}