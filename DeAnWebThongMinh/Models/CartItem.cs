#nullable disable
using System.ComponentModel.DataAnnotations;

namespace DeAnWebThongMinh.Models
{
    public class CartItem
    {
        [Key]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public float TotalPrice => ProductPrice * Quantity;
    }
}
