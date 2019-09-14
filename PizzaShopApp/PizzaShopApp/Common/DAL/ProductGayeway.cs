using PizzaShopApp.Common.Models.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PizzaShopApp.Common.DAL
{
    public class ProductGayeway : CommonGateway
    {
        public string SaveProduct(Product product)
        {

            int result = 0;
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_SaveProduct";
                Command.CommandType = CommandType.StoredProcedure;




                SqlParameter parameterProductName = new SqlParameter("@ProductName", product.ProductName);
                SqlParameter parameterProductDesc = new SqlParameter("@ProductDesc", product.ProductDescription);
                SqlParameter parameterProductPrice = new SqlParameter("@ProductPrice", product.ProductPrice);
                SqlParameter parameterProductPIC = new SqlParameter("@ProductIMG", product.ProductImage);
                SqlParameter parameteProductInStock = new SqlParameter("@ProductInStock", product.ProductInStock);

                Command.Parameters.Add(parameterProductName);
                Command.Parameters.Add(parameterProductDesc);
                Command.Parameters.Add(parameterProductPrice);
                Command.Parameters.Add(parameterProductPIC);
                Command.Parameters.Add(parameteProductInStock);


                Connection.Open();


                result = Command.ExecuteNonQuery();

                Connection.Close();


                if (result > 0)
                {
                    return "Product Save Successsfully";
                }
                else
                {
                    return "Failed To Save Product !!!!!";
                }
            }



        }

        public bool IsExists(string text)
        {

            int result = 0;
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_checkUniqueProduct";
                Command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterProductName = new SqlParameter("@ProductName", text);
                Command.Parameters.Add(parameterProductName);


                Connection.Open();
                result = (int)Command.ExecuteScalar();
                Connection.Close();
            }



            return result == -1;
        }

        public IEnumerable<Product> GetAllProducts()
        {

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                ICollection<Product> products = new Collection<Product>();

                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_Get_All_Product";
                Command.CommandType = CommandType.StoredProcedure;


                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {

                    Product product = new Product();

                    product.ProductId = Convert.ToInt32(reader["Id"]);
                    product.ProductName = reader["ProductName"].ToString();
                    product.ProductDescription = reader["Description"].ToString();
                    product.ProductPrice = Convert.ToInt64(reader["Price"]);
                    product.ProductImage = (byte[])reader["ProductImage"];
                    product.ProductInStock = Convert.ToInt32(reader["ProductInStock"]);

                    products.Add(product);
                }


                reader.Close();
                Connection.Close();
                return products;

            }





        }

        public Product GetProductById(int productId)
        {

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {

                ICollection<Product> products = new Collection<Product>();

                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_Get_Product_By_Id";
                Command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@ProductId", productId);


                Command.Parameters.Add(parameterId);
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                Product product = new Product();

                while (reader.Read())
                {


                    product.ProductId = Convert.ToInt32(reader["Id"]);
                    product.ProductName = reader["ProductName"].ToString();
                    product.ProductDescription = reader["Description"].ToString();
                    product.ProductPrice = Convert.ToInt64(reader["Price"]);
                    product.ProductImage = (byte[])reader["ProductImage"];
                    product.ProductInStock = Convert.ToInt32(reader["ProductInStock"]);


                }


                reader.Close();
                Connection.Close();
                return product;
            }
        }

        public string DeleteProduct(int i)
        {

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_DeleteProduct";
                Command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@ProductId", i);
                Command.Parameters.Add(parameter);
                string msg = null;

                Connection.Open();

                if (Command.ExecuteNonQuery() == 1)
                {
                    msg = "Deleted Successfully!";
                }
                else
                {
                    msg = "Invalid Input";
                }

                Connection.Close();


                return msg;
            }


        }

        public bool UpdateProduct(Product product)
        {

            int result = 0;
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;

                if (product.ProductImage.Count() == 1)
                {
                    Command.CommandText = "sp_UpdateProductWithOutImage";
                }
                else
                {
                    Command.CommandText = "sp_UpdateProduct";

                    SqlParameter parameterProductPIC = new SqlParameter("@ProductIMG", product.ProductImage);
                    Command.Parameters.Add(parameterProductPIC);
                }

                Command.CommandType = CommandType.StoredProcedure;






                SqlParameter parameterProductID = new SqlParameter("@ProductID", product.ProductId);
                SqlParameter parameterProductName = new SqlParameter("@ProductName", product.ProductName);
                SqlParameter parameterProductDesc = new SqlParameter("@ProductDesc", product.ProductDescription);
                SqlParameter parameterProductPrice = new SqlParameter("@ProductPrice", product.ProductPrice);
                SqlParameter parameteProductInStock = new SqlParameter("@ProductInStock", product.ProductInStock);

                Command.Parameters.Add(parameterProductName);
                Command.Parameters.Add(parameterProductDesc);
                Command.Parameters.Add(parameterProductPrice);
                Command.Parameters.Add(parameterProductID);
                Command.Parameters.Add(parameteProductInStock);


                Connection.Open();


                result = Command.ExecuteNonQuery();

                Connection.Close();



                return result == 1;

            }
        }




        public ICollection<OrderItems> GetAllSelectedCartProducts(IDictionary<int, int> cartProductItems)
        {
            IDictionary<int, int> productQuantity = cartProductItems;
            ICollection<OrderItems> items = new Collection<OrderItems>();


            foreach (KeyValuePair<int, int> productQ in productQuantity)
            {

                using (SqlConnection Connection = new SqlConnection(connectionString))
                {

                    ICollection<Product> products = new Collection<Product>();

                    SqlCommand Command = new SqlCommand();
                    Command.Connection = Connection;


                    Command.CommandText = "sp_Get_Product_By_Id";
                    Command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameterId = new SqlParameter("@ProductId", productQ.Key);


                    Command.Parameters.Add(parameterId);
                    Connection.Open();
                    SqlDataReader reader = Command.ExecuteReader();
                    Product product = new Product();

                    while (reader.Read())
                    {


                        product.ProductId = Convert.ToInt32(reader["Id"]);
                        product.ProductName = reader["ProductName"].ToString();
                        product.ProductDescription = reader["Description"].ToString();
                        product.ProductPrice = Convert.ToInt64(reader["Price"]);
                        product.ProductImage = (byte[])reader["ProductImage"];


                        OrderItems orderItem = new OrderItems()
                        {

                            Product = product,
                            Quantity = productQ.Value,
                            TotalPrice = (product.ProductPrice * productQ.Value)

                        };
                        items.Add(orderItem);

                    }


                    reader.Close();
                    Connection.Close();


                }
            }


            return items;
        }


        public IEnumerable<Product> GetProductsByName(string productName)
        {

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                ICollection<Product> products = new Collection<Product>();

                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_Get_Product_By_Name";
                Command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterProductName = new SqlParameter("@ProductName", productName);
                Command.Parameters.Add(parameterProductName);


                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {

                    Product product = new Product();

                    product.ProductId = Convert.ToInt32(reader["Id"]);
                    product.ProductName = reader["ProductName"].ToString();
                    product.ProductDescription = reader["Description"].ToString();
                    product.ProductPrice = Convert.ToInt64(reader["Price"]);
                    product.ProductImage = (byte[])reader["ProductImage"];
                    product.ProductInStock = Convert.ToInt32(reader["ProductInStock"]);


                    products.Add(product);
                }


                reader.Close();
                Connection.Close();

                return products;

            }

        }


    }
}