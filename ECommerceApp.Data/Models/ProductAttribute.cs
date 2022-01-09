using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ECommerceApp.Data.Models
{
    public partial class ProductAttribute
    {
        [Key]

        public int ProductAttrId { get; set; }
        public long ProductId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }


        public virtual ProductAttributeLookup Attribute { get; set; }
        public virtual Product Product { get; set; }
    }

    public partial class AttributeLookUpMapping : ProductAttribute
    {
        public string AttributeName { get; set; }
    }
}
