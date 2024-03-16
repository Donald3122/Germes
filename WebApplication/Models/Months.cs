using System;
using System.Collections.Generic;
namespace WebApplication.Models
{
    public partial class Months
    {
        public Months()
        {
            Salary = new HashSet<Salary>();
        }

        public byte Id { get; set; }
        public string MonthName { get; set; }

        public virtual ICollection<Salary> Salary { get; set; }
    }
}
