using System;
using System.Collections.Generic;
namespace WebApplication.Models
{
    public partial class Saleofproducts
    {
        public short Id { get; set; }
        public short? Product { get; set; }
        public float? CountSaleofpr { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

        public virtual Employees EmployeeNavigation { get; set; }
        public virtual Finproducts ProductNavigation { get; set; }
    }
}
