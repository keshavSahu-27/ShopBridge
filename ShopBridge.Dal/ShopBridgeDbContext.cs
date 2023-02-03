using Microsoft.EntityFrameworkCore;
using ShopBridge.Dal.Entities;

namespace ShopBridge.Dal;

public class ShopBridgeDbContext : DbContext
{
    public ShopBridgeDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
    {}

    public DbSet<Inventory> Inventory { get; set; }
}

