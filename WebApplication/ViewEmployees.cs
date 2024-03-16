using System;
using System.Collections.Generic;
namespace WebApplication
{
    public partial class ViewEmployees
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
