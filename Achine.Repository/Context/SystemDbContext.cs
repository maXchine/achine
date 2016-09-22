using System.Data.Entity;
using Achine.Model;
using Achine.Model.System;

namespace Achine.Repository.Context {

    public class SystemDbContext : DbContext {

        public SystemDbContext()
            : base("name=SystemDbContext") { }

        public SystemDbContext(string connString) : base(connString) { }

        public DbSet<Administrator> Accounts { get; set; }

    }
}

