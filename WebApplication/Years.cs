using System;
using System.Collections.Generic;
using WebApplication.Models;
namespace WebApplication
{
    public partial class Years
    {
        public Years()
        {
            Salary = new HashSet<Salary>();
        }

        public int YearName { get; set; }

        public virtual ICollection<Salary> Salary { get; set; }
    }
}
