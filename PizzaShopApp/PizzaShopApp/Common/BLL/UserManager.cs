using PizzaShopApp.Common.DAL;
using PizzaShopApp.Common.Models.Data;

namespace PizzaShopApp.Common.BLL
{
    public class UserManager
    {
        private UserGateway _userGateway = new UserGateway();

        public bool ValidateUserData(User user)
        {

            if (user.UserName == null || user.Password == null || user.Address == null)
            {
                return false;
            }
            return true;
        }




        public string SaveUser(User user)
        {
            return _userGateway.SaveUser(user);
        }

        public bool UserUniqueEmailValidation(string email)
        {
            return _userGateway.UserUniqueEmailValidation(email);
        }

        public int GetUserRollByEmail(string email, string pass)
        {
            return _userGateway.GetUserRollByEmail(email, pass);
        }

        public string GetUserIdByEmail(string email)
        {

            return _userGateway.GetUserIdByEmailAddress(email);
        }
    }
}