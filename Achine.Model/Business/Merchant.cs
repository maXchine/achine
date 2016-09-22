using System;
using System.ComponentModel.DataAnnotations;

namespace Achine.Model.Business {
    public class Merchant {

        public Guid Id { get; set; }

        [StringLength(18, MinimumLength = 6)]
        public string Password { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }

        public string SiteName { get; set; }

        public string PrivateKey { get; set; }

        public string ValidateKey { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 积分兑换比例
        /// </summary>
        public decimal KekeRate { get; set; }


    }
}
