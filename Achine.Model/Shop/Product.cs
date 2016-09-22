using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Achine.Model.Shop {

    public class Product {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int KekePrice { get; set; }

        public decimal SalePrice { get; set; }

        public decimal PurchasePrice { get; set; }

        public Guid CategoryId { get; set; }


        [Range(0, 99999)]
        public int Storage { get; set; }


        #region + navigation properties

        [IgnoreDataMember]
        public Category Category { get; set; }

        #endregion

    }
}