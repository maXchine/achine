
using Achine.Common.Data.Entity;
using Achine.Model;
using Achine.Model.System;
using Achine.Repository.Context;

namespace Achine.Repository.Repositories {
    internal class AccountRepository : Repository<SystemDbContext, Administrator>, IAccountRepository {

    }
}
