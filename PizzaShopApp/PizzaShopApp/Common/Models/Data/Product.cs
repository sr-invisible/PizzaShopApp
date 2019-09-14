
namespace PizzaShopApp.Common.Models.Data
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public byte[] ProductImage { get; set; }

        public int ProductInStock { get; set; }

    }
}