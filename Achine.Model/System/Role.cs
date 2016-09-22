using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Achine.Model.System {

    /// <summary>
    /// System Role. 
    /// </summary>
    [Table("sys_role")]
    public class Role {

        /// <summary>
        /// Role Id in this system.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Role name.
        /// String length betwen 2 to 32.
        /// </summary>
        [StringLength(32, MinimumLength = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Discription of this role.
        /// Max length is 128.
        /// </summary>
        [StringLength(128)]
        public string Discription { get; set; }
    }
}
