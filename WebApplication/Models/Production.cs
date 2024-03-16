using System;
using System.Collections.Generic;
namespace WebApplication.Models
{
    public partial class Production
    {
        public short Id { get; set; }
        public short? Product { get; set; }
        public float? CountProduction { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

        public virtual Employees EmployeeNavigation { get; set; }
        public virtual Finproducts ProductNavigation { get; set; }
    }
}
