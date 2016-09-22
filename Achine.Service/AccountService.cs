
using Achine.Model;
using Achine.Model.System;
using Achine.Repository;

using Microsoft.Practices.Unity;

namespace Achine.Service {
    public class AccountService : IAccountService {

        [Dependency]
        public IAccountRepository AccountRepository { get; set; }

        public Administrator Login(string loginName, string password) {


            var user = AccountRepository.GetEntity(m => m.Username == loginName || m.Email == loginName || m.Phone == loginName);

            if (user == null)
                throw new ControlException("用户不存在");

            if (user.Password != password)
                throw new ControlException("密码错误");

            return user;
        }
    }
}
