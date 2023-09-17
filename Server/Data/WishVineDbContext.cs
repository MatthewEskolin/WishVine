using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WishVine.Server.DomainData;

namespace WishVine.Server.Data;

public class WishVineDbContext:IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
{
    public WishVineDbContext(DbContextOptions<WishVineDbContext> options) : base(options)
    {
    }

    public DbSet<WishList> WishLists { get; set; } = null!;
    public DbSet<WishListItem> WishListItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WishList>().HasMany(x => x.Items).WithOne(x => x.WishList);


        // Configure the primary key for IdentityUserLogin<TKey>
        modelBuilder.Entity<IdentityUserLogin<int>>()
            .HasKey(l => new { l.UserId, l.LoginProvider });

        modelBuilder.Entity<IdentityUserRole<int>>()
            .HasKey(l => new { l.RoleId  });

        modelBuilder.Entity<IdentityUserToken<int>>()
            .HasKey(l => new { l.UserId});

    }
}

public class ApplicationUser : IdentityUser<int>
{
    //[Key]
    //public int UserID { get; set; }
    //public string DisplayName { get; set; } = null!;
    //public List<WishList> WishLists { get; set; } = new();
}

