using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.Models
{
    public class ShoppingItem
    {
       
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public bool IsPickedUp { get; set; } 
    }
}
