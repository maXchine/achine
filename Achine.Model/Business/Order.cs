using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Achine.Model.Business {

    public class Order {

        [Key]
        public string OrderId { get; set; }


        public string Date { get; set; }

        /// <summary>
        /// 商户编号
        /// </summary>
        public string MerId { get; set; }
    }
}

