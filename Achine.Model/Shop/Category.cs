using System;

namespace Achine.Model.Shop {

    public class Category {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public string Description { get; set; }
    }

}