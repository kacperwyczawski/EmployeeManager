using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Models
{
    [Table("departments")]
    [Index("DeptName", Name = "dept_name", IsUnique = true)]
    public partial class Department
    {
        public Department()
        {
            DeptEmps = new HashSet<DeptEmp>();
            DeptManagers = new HashSet<DeptManager>();
        }

        [Key]
        [Column("dept_no")]
        [StringLength(4)]
        public string DeptNo { get; set; } = null!;
        [Column("dept_name")]
        [StringLength(40)]
        public string DeptName { get; set; } = null!;

        [InverseProperty("DeptNoNavigation")]
        public virtual ICollection<DeptEmp> DeptEmps { get; set; }
        [InverseProperty("DeptNoNavigation")]
        public virtual ICollection<DeptManager> DeptManagers { get; set; }
    }
}
