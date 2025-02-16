﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Models
{
    [Table("dept_manager")]
    [Index("DeptNo", Name = "dept_no")]
    public class DeptManager : IJob
    {
        [Key]
        [Column("emp_no")]
        public int EmpNo { get; set; }
        [Key]
        [Column("dept_no")]
        [StringLength(4)]
        public string DeptNo { get; set; } = null!;
        [Column("from_date")]
        public DateOnly FromDate { get; set; }
        [Column("to_date")]
        public DateOnly ToDate { get; set; }

        [ForeignKey("DeptNo")]
        [InverseProperty("DeptManagers")]
        public Department DeptNoNavigation { get; set; } = null!;
        [ForeignKey("EmpNo")]
        [InverseProperty("DeptManagers")]
        public Employee EmpNoNavigation { get; set; } = null!;
    }
}
