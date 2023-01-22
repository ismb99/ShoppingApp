using ShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Repository.IRepository
{
    public interface IShoppingRepository
    {
        Task<List<ShoppingItem>> GetAllAsync();
        Task<ShoppingItem> GetAsync(int id);
        void Delete(int id);
        Task<ShoppingItem> AddAsync(ShoppingItem shoppingItem);
        Task<ShoppingItem> UpdateAsync(ShoppingItem shoppingItem);
    }
}
