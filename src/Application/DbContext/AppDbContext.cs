using Domain.Entities;
using Domain.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Application.DbContext
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole,
        AppUserLogin, AppRoleClaim, AppUserToken>
    {
        
       public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
       public DbSet<Category> Categories =>Set<Category>();
       public DbSet<Product> Products =>Set<Product>();
       public DbSet<OrderItem> OrderItems =>Set<OrderItem>();
       public DbSet<Order> Orders =>Set<Order>();
       public DbSet<Color> Colors => Set<Color>();
       public DbSet<Material> Materials => Set<Material>();
       public DbSet<ProductImage> ProductImages => Set<ProductImage>();
       public DbSet<ProductColors> ProductColors => Set<ProductColors>();
       public DbSet<ProductMaterials> ProductMaterials => Set<ProductMaterials>();
       public DbSet<Gender> Genders => Set<Gender>();
        
    }
}
