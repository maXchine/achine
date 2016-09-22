
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Achine.Model.System {

    [Table("sys_adm")]
    public class Administrator {

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Realname { get; set; }


    }
}
