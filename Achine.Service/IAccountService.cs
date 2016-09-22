using Achine.Model;
using Achine.Model.System;

namespace Achine.Service {

    public interface IAccountService {

        Administrator Login(string loginName, string password);

    }
}
