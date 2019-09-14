
namespace PizzaShopApp.Common.Models.ViewModels
{
    public class OrderRecord
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }

        public string Address { get; set; }
        public string DateTime { get; set; }
        public double TotalPrice { get; set; }



    }
}