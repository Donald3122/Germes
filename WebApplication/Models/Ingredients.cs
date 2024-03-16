using System;
using System.Collections.Generic;
namespace WebApplication.Models
{
    public partial class Ingredients
    {
        public short Id { get; set; }
        public short? Product { get; set; }
        public short? RawMaterials { get; set; }
        public float? Countingred { get; set; }

        public virtual Finproducts ProductNavigation { get; set; }
        public virtual Rawmaterials RawMaterialsNavigation { get; set; }
    }
}
