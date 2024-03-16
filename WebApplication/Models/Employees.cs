using System;
using System.Collections.Generic;
namespace WebApplication.Models{
    public partial class Employees
    {
        public Employees()
        {
            Production = new HashSet<Production>();
            PurchaseOfrawmaterials = new HashSet<PurchaseOfrawmaterials>();
            SalaryNavigation = new HashSet<Salary>();
            Saleofproducts = new HashSet<Saleofproducts>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public short? Position { get; set; }
        public decimal? Salary { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

        public virtual Positions PositionNavigation { get; set; }
        public virtual ICollection<Production> Production { get; set; }
        public virtual ICollection<PurchaseOfrawmaterials> PurchaseOfrawmaterials { get; set; }
        public virtual ICollection<Salary> SalaryNavigation { get; set; }
        public virtual ICollection<Saleofproducts> Saleofproducts { get; set; }
    }
}
