using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Data;
using ShoppingAPI.Models;
using ShoppingAPI.Repository.IRepository;

namespace ShoppingAPI.Repository
{
    public class ShoppingRepository : IShoppingRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ShoppingRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ShoppingItem> AddAsync(ShoppingItem shoppingItem)
        {
            var result = await _applicationDbContext.ShoppingItems.AddAsync(shoppingItem);
            await _applicationDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public void Delete(int id)
        {
            var shoppingItem = _applicationDbContext.ShoppingItems.FirstOrDefault(x => x.Id == id);
            if(shoppingItem != null) 
            { 
                _applicationDbContext.Remove(shoppingItem);
                _applicationDbContext.SaveChanges();
            }
        }

        public async Task<List<ShoppingItem>> GetAllAsync()
        {
            return await _applicationDbContext.ShoppingItems.ToListAsync();
        }

        public async Task<ShoppingItem> GetAsync(int id)
        {
            return await _applicationDbContext.ShoppingItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ShoppingItem> UpdateAsync(ShoppingItem shoppingItem)
        {
            var result = await _applicationDbContext.ShoppingItems.FirstOrDefaultAsync(x => x.Id == shoppingItem.Id);
            if(result != null)
            {
                result.Amount = shoppingItem.Amount;
                result.Name = shoppingItem.Name;
                result.IsPickedUp = shoppingItem.IsPickedUp;

                await _applicationDbContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
