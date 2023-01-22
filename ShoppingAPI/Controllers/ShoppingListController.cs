using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;
using ShoppingAPI.Repository.IRepository;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingRepository _shoppingRepository;

        public ShoppingListController(IShoppingRepository shoppingRepository)
        {
            _shoppingRepository = shoppingRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<ShoppingItem>>> GetAll()
        {
            return await _shoppingRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task <ActionResult<ShoppingItem>> Post([FromBody] ShoppingItem shoppingItem)
        {
            if(shoppingItem == null)
            {
                return BadRequest();
            }
            var result =  await _shoppingRepository.AddAsync(shoppingItem);

            return Ok(result);
        }



     







    }
}
