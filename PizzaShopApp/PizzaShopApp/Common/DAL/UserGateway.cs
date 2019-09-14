using PizzaShopApp.Common.Models.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PizzaShopApp.Common.DAL
{
    public class UserGateway : CommonGateway
    {




        public string SaveUser(User user)
        {

            int result = 0;
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_saveUser";
                Command.CommandType = CommandType.StoredProcedure;



                SqlParameter parameterUserName = new SqlParameter("@UserName", user.UserName);
                SqlParameter parameterPassword = new SqlParameter("@Password", user.Password);
                SqlParameter parameterEmail = new SqlParameter("@Email", user.Email);
                SqlParameter parameterAddress = new SqlParameter("@Address", user.Address);
                SqlParameter parameterUserRoll = new SqlParameter("@RollId", (int)UserRoll.RegularUser);


                Command.Parameters.Add(parameterUserName);
                Command.Parameters.Add(parameterPassword);
                Command.Parameters.Add(parameterEmail);
                Command.Parameters.Add(parameterAddress);
                Command.Parameters.Add(parameterUserRoll);


                Connection.Open();


                result = Command.ExecuteNonQuery();

                Connection.Close();

            }




            string msg = "";
            if (result == 1)
            {
                msg += "Registared Successfully";
            }
            else
            {
                msg += "Failed To Save";
            }


            return msg;
        }

        public bool UserUniqueEmailValidation(string email)
        {


            int result = 0;
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_checkUniqueEmail";
                Command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterEmail = new SqlParameter("@Email", email);
                Command.Parameters.Add(parameterEmail);


                Connection.Open();
                result = (int)Command.ExecuteScalar();
                Connection.Close();
            }



            return result == 1;
        }

        public string GetUserIdByEmailAddress(string userEmail)
        {


            /*
                        (*/


            string result = null;

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_GetUserIdByEmailAddress";
                Command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterEmail = new SqlParameter("@Email", userEmail);


                Command.Parameters.Add(parameterEmail);


                Connection.Open();
                result = Command.ExecuteScalar().ToString();
                Connection.Close();
            }


            return result.ToString();




        }

        public int GetUserRollByEmail(string email, string password)
        {

            object result;
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {


                SqlCommand Command = new SqlCommand();
                Command.Connection = Connection;


                Command.CommandText = "sp_GetUserRollByEmail";
                Command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterEmail = new SqlParameter("@Email", email);
                SqlParameter parameterPass = new SqlParameter("@Pass", password);


                Command.Parameters.Add(parameterEmail);
                Command.Parameters.Add(parameterPass);


                Connection.Open();
                result = Command.ExecuteScalar();
                Connection.Close();
            }
            int res = Convert.ToInt32(result);


            return res;
        }
    }
}