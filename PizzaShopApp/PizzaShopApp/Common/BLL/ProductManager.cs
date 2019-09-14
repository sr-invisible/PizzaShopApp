using PizzaShopApp.Common.DAL;
using PizzaShopApp.Common.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShopApp.Common.BLL
{
    public class ProductManager
    {
        private ProductGayeway _productGayeway = new ProductGayeway();

        private UserGateway _userGateway = new UserGateway();
        public string SaveProduct(Product product)
        {
            return _productGayeway.SaveProduct(product);
        }

        public bool IsExists(string text)
        {
            return _productGayeway.IsExists(text);
        }

        public IEnumerable<Product> GetAllProducts()
        {

            return _productGayeway.GetAllProducts();
        }

        public IEnumerable<Product> GetProductById(int productId)
        {

            var product = _productGayeway.GetProductById(productId);




            return new List<Product> { product };

        }

        public string DeleteProduct(int i)
        {

            return _productGayeway.DeleteProduct(i);

        }

        public bool UpdateProduct(Product product)
        {
            return _productGayeway.UpdateProduct(product);
        }

        public ICollection<OrderItems> GetAllSelectedCartProducts(string[] cartProductItems)
        {

            return _productGayeway.GetAllSelectedCartProducts(GetProductIdAndQuantity(cartProductItems));


        }

        public string RemoveProductFromCart(IDictionary<int, int> productItemDictionary, int productId)
        {

            StringBuilder builder = new StringBuilder();

            IDictionary<int, int> dictionaryOfProductInfo = productItemDictionary;

            dictionaryOfProductInfo.Remove(productId);

            foreach (var product in dictionaryOfProductInfo)
            {


                builder.Append("|" + product.Key + "," + product.Value);


            }

            return builder.ToString();
        }


        public IEnumerable<Product> GetProductsByName(string productName)
        {

            return _productGayeway.GetProductsByName(productName);
        }



        public IDictionary<int, int> GetProductIdAndQuantity(string[] productItemsArray)
        {
            IDictionary<int, int> ints = new Dictionary<int, int>();

            for (int i = 1; i < productItemsArray.Length; i++)
            {




                string[] ss = productItemsArray[i].Split(',');
                string key = ss[0].Trim();
                string value = ss[1].Trim();

                int productID = Convert.ToInt32(key);
                int productQnt = Convert.ToInt32(value);

                if (ints.ContainsKey(productID))
                {
                    ints[productID] = productQnt;
                }
                else
                {
                    ints.Add(productID, productQnt);
                }




            }

            return ints;
        }

        public bool CheckProductInStock(string txtNumberOfProduct, string s)
        {


            int productId = Convert.ToInt32(s);

            int quantity = 0;

            int.TryParse(txtNumberOfProduct, out quantity);



            var product = _productGayeway.GetProductById(productId);

            return product.ProductInStock >= quantity;

        }
    }
}