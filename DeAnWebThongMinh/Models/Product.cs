using System.ComponentModel.DataAnnotations;
#nullable disable
namespace DeAnWebThongMinh.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity {  get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}