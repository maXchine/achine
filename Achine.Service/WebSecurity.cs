
using System.Web;
using System.Web.Mvc;
using Achine.Model;
using Achine.Model.System;
using Achine.Repository;

namespace Achine.Service {
    public class WebSecurity {

        public static void Login(string loginName, string password, bool rememberMe) {

            var rep = DependencyResolver.Current.GetService<IAccountRepository>();
            var user = rep.GetEntity(m => m.Username == loginName || m.Email == loginName || m.Phone == loginName);

            if (user == null)
                throw new ControlException("用户不存在");

            if (user.Password != password)
                throw new ControlException("密码错误");

            CurrentUser = user;
        }

        private struct SessionKey {
            internal const string CurrentUser = "CurrentUser";
        }



        public static Administrator CurrentUser {
            get { return HttpContext.Current.Session[SessionKey.CurrentUser] as Administrator; }
            set { HttpContext.Current.Session[SessionKey.CurrentUser] = value; }
        }

        public static void Logout() {
            CurrentUser = null;
        }
    }
}
