using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Web.Models;

public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
{
    private const string adminUser = "Admin";
    private const string adminPassword = "Secret123$";

    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) 
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var admin = new IdentityUser { UserName = adminUser };

        //set user password
        PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = ph.HashPassword(admin, adminPassword);

        //seed user
        builder.Entity<IdentityUser>().HasData(admin);
        base.OnModelCreating(builder);
    }
}
