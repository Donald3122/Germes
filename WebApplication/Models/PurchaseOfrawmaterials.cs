using System;
using System.Collections.Generic;
namespace WebApplication.Models
{
    public partial class PurchaseOfrawmaterials
    {
        public short Id { get; set; }
        public short? RawMaterials { get; set; }
        public float? CountPur { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

        public virtual Employees EmployeeNavigation { get; set; }
        public virtual Rawmaterials RawMaterialsNavigation { get; set; }
    }
}
