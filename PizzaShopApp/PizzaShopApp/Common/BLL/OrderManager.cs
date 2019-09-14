using PizzaShopApp.Common.DAL;
using System;
using System.Collections.Generic;
using PizzaShopApp.Common.Models.Data;
using PizzaShopApp.Common.Models.ViewModels;

namespace PizzaShopApp.Common.BLL
{
    public class OrderManager
    {
        private OrderGateway _orderGateway = new OrderGateway();
        private UserGateway _userGateway = new UserGateway();
        public string SaveOrderAndOrderItems(string[] productItemsArray, string userId)
        {

            IDictionary<int, int> itemsDictionary = new Dictionary<int, int>();
            foreach (var cartProductItem in productItemsArray)
            {
                string[] cartProductItemArray = cartProductItem.Split(',');

                if (cartProductItem.Length > 1)
                {
                    itemsDictionary.Add(Convert.ToInt32(cartProductItemArray[0]),
                        Convert.ToInt32(cartProductItemArray[1]));
                }
            }

            int usrId = Convert.ToInt32(userId);
            string msg = _orderGateway.SaveOrderAndOrderItems(itemsDictionary, usrId);
            return msg;
        }

        public IEnumerable<OrderRecord> GetAllOrderRecords()
        {
            return _orderGateway.GetAllOrderRecords();
        }

        public IEnumerable<OrderItemDetails> GetAllOrderItemInfo(string s)
        {
            return _orderGateway.GetAllOrderItemInfo(s);
        }
    }
}