using System;
using System.Collections.Generic;
namespace WebApplication.Models{
    public partial class Salary
    {
        public int Id { get; set; }
        public int? Year { get; set; }
        public byte? Month { get; set; }
        public int? Employee { get; set; }
        public byte? ParticipationPurchase { get; set; }
        public byte? ParticipationSale { get; set; }
        public byte? ParticipationProduction { get; set; }
        public byte? CountParticipation { get; set; }
        public decimal? SalaryEmployee { get; set; }
        public float? TotalAmount { get; set; }
        public bool? Issued { get; set; }
        public float? Bonus { get; set; }

        public virtual Employees EmployeeNavigation { get; set; }
        public virtual Months MonthNavigation { get; set; }
        public virtual Years YearNavigation { get; set; }
    }
}
