using PizzaShopApp.Common.Models.Data;
using PizzaShopApp.Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PizzaShopApp.Common.DAL
{
    public class OrderGateway : CommonGateway
    {

        private ProductGayeway _productGayeway = new ProductGayeway();

        public string SaveOrderAndOrderItems(IDictionary<int, int> itemsDictionary, int userId)
        {
            string msg = null;
            ICollection<OrderItems> items = _productGayeway.GetAllSelectedCartProducts(itemsDictionary);

            double totalOrderedProductPrice = items.Sum(TItem => TItem.TotalPrice);
            int orderId = SaveOrder(userId, totalOrderedProductPrice);


            if (orderId == 0)
            {
                msg = "Failed To Make Order";
            }
            else
            {
                msg = SaveOrderedItems(items, orderId);
            }
            return msg;
        }


        private string SaveOrderedItems(ICollection<OrderItems> items, int orderId)
        {

            string msg = null;
            int saved = 0;
            foreach (var orderItemse in items)
            {
                saved = SaveProductItems(orderId, orderItemse.Product.ProductId, orderItemse.Quantity, orderItemse.TotalPrice);

            }

            if (saved == 1)
            {
                msg = "Successfully Order Has Been Given";
            }


            return msg;
        }

        private int SaveProductItems(int orderId, int productId, int quantity, double totalPrice)
        {
            int rowEffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand(connectionString);


                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "sp_SaveOrderItems";
                sqlCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter parameterOrderId = new SqlParameter("@OrderID", orderId);
                SqlParameter parameterProductID = new SqlParameter("@ProductID", productId);
                SqlParameter parameterQuantity = new SqlParameter("@Quantity", quantity);
                SqlParameter parameterTotalPrice = new SqlParameter("@TotalPrice", totalPrice);




                sqlCommand.Parameters.Add(parameterProductID);
                sqlCommand.Parameters.Add(parameterOrderId);
                sqlCommand.Parameters.Add(parameterQuantity);
                sqlCommand.Parameters.Add(parameterTotalPrice);

                connection.Open();
                rowEffected = sqlCommand.ExecuteNonQuery();
                connection.Close();





            }


            return rowEffected;
        }


        private int SaveOrder(int userId, double totalOrderedProductPrice)
        {
            string orderId = null;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "sp_SaveOrder";
                command.CommandType = CommandType.StoredProcedure;



                SqlParameter parameterUserId = new SqlParameter("@UserId", userId);
                SqlParameter parameterTotalOrderPrice = new SqlParameter("@TotalOrderPeice", totalOrderedProductPrice);


                command.Parameters.Add(parameterTotalOrderPrice);
                command.Parameters.Add(parameterUserId);


                connection.Open();
                orderId = command.ExecuteScalar().ToString();
                connection.Close();


            }

            int j = Convert.ToInt32(orderId);

            return j;
        }


        public IEnumerable<OrderRecord> GetAllOrderRecords()
        {



            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                ICollection<OrderRecord> orderRecords = new Collection<OrderRecord>();

                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;
                Command.CommandText = "SELECT * FROM VW_OrderRecords";



                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    OrderRecord record = new OrderRecord();


                    record.OrderId = Convert.ToInt32(reader["OrderId"]);
                    record.Address = reader["Address"].ToString();
                    record.DateTime = reader["Date"].ToString();
                    record.UserName = reader["UserName"].ToString();
                    record.TotalPrice = Convert.ToInt64(reader["TotalOrderPrice"]);

                    orderRecords.Add(record);
                }


                reader.Close();
                Connection.Close();
                return orderRecords;

            }






        }


        public IEnumerable<OrderItemDetails> GetAllOrderItemInfo(string s)
        {
            var orderId = Convert.ToInt32(s);


            using (SqlConnection Connection = new SqlConnection(connectionString))
            {

                ICollection<OrderItemDetails> orderItemDetailses = new Collection<OrderItemDetails>();

                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_OrderIntemDetails";
                Command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@OrderID", orderId);
                Command.Parameters.Add(parameter);


                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {

                    OrderItemDetails details = new OrderItemDetails();


                    details.ProductName = reader["ProductName"].ToString();
                    details.ProductQuantity = Convert.ToInt32(reader["Quantity"]);
                    details.ProductTotapPrice = Convert.ToInt64(reader["TotalPrice"]);

                    orderItemDetailses.Add(details);
                }


                reader.Close();
                Connection.Close();
                return orderItemDetailses;

            }


        }
    }
}