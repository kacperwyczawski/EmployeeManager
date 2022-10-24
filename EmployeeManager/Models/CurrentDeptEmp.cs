using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Models
{
    [Keyless]
    public partial class CurrentDeptEmp
    {
        [Column("emp_no")]
        public int EmpNo { get; set; }
        [Column("dept_no")]
        [StringLength(4)]
        public string DeptNo { get; set; } = null!;
        [Column("from_date")]
        public DateOnly? FromDate { get; set; }
        [Column("to_date")]
        public DateOnly? ToDate { get; set; }
    }
}
