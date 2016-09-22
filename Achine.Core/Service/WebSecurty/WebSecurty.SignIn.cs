using System.Web;
using Achine.Core.Constant;

namespace Achine.Core.Service.WebSecurty
{

    partial class WebSecurty
    {
        public static bool UserSignIn(string userName, string password, bool remembered = false)
        {

            return false;
        }

        public static void UserSignOut()
        {
            HttpContext.Current.Session[SessionKeys.SingedUser] = null;
        }

        public static void RememberMe()
        {

        }
    }
}
