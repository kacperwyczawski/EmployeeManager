using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Models
{
    [Keyless]
    public partial class DeptEmpLatestDate
    {
        [Column("emp_no")]
        public int EmpNo { get; set; }
        [Column("from_date")]
        public DateOnly? FromDate { get; set; }
        [Column("to_date")]
        public DateOnly? ToDate { get; set; }
    }
}
