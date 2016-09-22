
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Achine.Model.System {

    /// <summary>
    /// 
    /// </summary>
    [Table("sys_org")]
    public class Organization {

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string EnName { get; set; }

        public string Code { get; set; }

        public Guid? ParentId { get; set; }

        public string Description { get; set; }
    }
}
