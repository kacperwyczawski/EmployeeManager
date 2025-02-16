﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Models
{
    [Table("salaries")]
    public partial class Salary
    {
        [Key]
        [Column("emp_no")]
        public int EmpNo { get; set; }
        [Column("salary")]
        public int Salary1 { get; set; }
        [Key]
        [Column("from_date")]
        public DateOnly FromDate { get; set; }
        [Column("to_date")]
        public DateOnly ToDate { get; set; }

        [ForeignKey("EmpNo")]
        [InverseProperty("Salaries")]
        public virtual Employee EmpNoNavigation { get; set; } = null!;
    }
}
