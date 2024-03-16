using System;
using System.Collections.Generic;
namespace WebApplication.Models
{
    public partial class Budgets
    {
        public int Id { get; set; }
        public decimal? Budgetamount { get; set; }
        public float? SalePercentage { get; set; }
        public float? Bonus { get; set; }
    }
}
