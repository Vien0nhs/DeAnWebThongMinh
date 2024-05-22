using System.ComponentModel.DataAnnotations;
#nullable disable
namespace DeAnWebThongMinh.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductType {  get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public string Description {  get; set; }
        public string ImageUrl {  get; set; }
    }
}