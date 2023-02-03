using ShopBridge.Dal.Entities;
namespace ShopBridge.Repository.Contracts
{
    public interface IInventoryRepository
    {
        public Task<IEnumerable<Inventory>> FetchInventories();

        public Task<Inventory> FetchInventoryById(long id);

        public Task<Inventory?> CreateInventory(Inventory inventory);

        public Task<Inventory?> UpdateInventory(Inventory inventory);

        public Task<bool> DeleteInventory(Inventory inventory);
    }
}

