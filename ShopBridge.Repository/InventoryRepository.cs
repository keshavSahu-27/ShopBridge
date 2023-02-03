using System;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Dal;
using ShopBridge.Dal.Entities;
using ShopBridge.Repository.Contracts;
using ShopBridge.Repository.Exceptions;

namespace ShopBridge.Repository;
public class InventoryRepository : IInventoryRepository
{
    public InventoryRepository(ShopBridgeDbContext dbContext) {
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<Inventory>> FetchInventories() =>
        await _dbContext.Inventory.ToListAsync();

    public async Task<Inventory?> CreateInventory(Inventory inventory)
    {
        //Set Id to 0 so that sql server can generate the specific id when create, no user should have right to take the specific id.
        inventory.Id = 0;

        //set date time for added and last modified dates
        inventory.AddedDate = DateTime.Today;
        inventory.LastModified = DateTime.Today;

        _dbContext.Inventory.Add(inventory);
        var isSuccess = await _dbContext.SaveChangesAsync();
        return isSuccess > 0 ? inventory : null;
    }

    public async Task<Inventory> FetchInventoryById(long id)
    {
        var item = await _dbContext.Inventory.FindAsync(id);
        if (item == null)
            throw new RecordNotFoundException("Could not find the record with the provided detail");

        return item;

    }

    public async Task<Inventory?> UpdateInventory(Inventory inventory)
    {
        //set last modified dates
        inventory.LastModified = DateTime.Today;

        var item = await _dbContext.Inventory.FindAsync(inventory.Id);
        if (item == null)
            throw new RecordNotFoundException("Could not find the record to update");

        item = inventory;
        _dbContext.Inventory.Update(item);

        var isSuccess = await _dbContext.SaveChangesAsync();

        return isSuccess > 0 ? inventory : null;
    }

    public async Task<bool> DeleteInventory(Inventory inventory)
    {
        var item = await _dbContext.Inventory.FindAsync(inventory.Id);
        if (item == null)
            throw new RecordNotFoundException("Could not find the record to update");

        _dbContext.Inventory.Remove(inventory);

        var isSuccess = await _dbContext.SaveChangesAsync();

        return isSuccess > 0;
    }

    #region Helpers

    private readonly ShopBridgeDbContext _dbContext;

    #endregion
}

