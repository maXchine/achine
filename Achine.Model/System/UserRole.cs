using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Achine.Model.System {


    /// <summary>
    /// Roles of Users.
    /// </summary>
    [Table("sys_user_role")]
    public class UserRole {

        /// <summary>
        /// Serial number.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User's Id in this system.
        /// </summary>
        [Key]
        public Guid UserId { get; set; }

        /// <summary>
        /// Role's Id in this system.
        /// </summary>
        [Key]
        public Guid RoleId { get; set; }


        #region + navigation properties

        /// <summary>
        /// User ID corresponds to the user information.
        /// </summary>
        [IgnoreDataMember]
        [ForeignKey("UserId")]
        public User User { get; set; }


        /// <summary>
        /// Role ID corresponds to the role information.
        /// </summary>
        [IgnoreDataMember]
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        #endregion
    }
}
