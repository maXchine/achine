using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Achine.Model.System {

    /// <summary>
    /// System users. 
    /// Manager of the System.
    /// </summary>
    [Table("sys_users")]
    public class User {

        /// <summary>
        /// User Id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Custom username. (default value is phone number)
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User's mobile phone numbers.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// User email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User idnumber.
        /// </summary>
        public string IdNo { get; set; }

        /// <summary>
        /// User realname.
        /// </summary>
        public string Realname { get; set; }

        /// <summary>
        /// Crate date of this record.
        /// </summary>
        public DateTime CreateDate { get; set; }


    }
}
