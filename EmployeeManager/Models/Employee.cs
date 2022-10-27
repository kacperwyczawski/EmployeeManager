using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Models
{
    [Table("employees")]
    public partial class Employee
    {
        public Employee()
        {
            DeptEmps = new HashSet<Job>();
            DeptManagers = new HashSet<DeptManager>();
            Salaries = new HashSet<Salary>();
            Titles = new HashSet<Title>();
        }

        [Key]
        [Column("emp_no")]
        public int EmpNo { get; set; }
        [Column("birth_date")]
        public DateOnly BirthDate { get; set; }
        [Column("first_name")]
        [StringLength(14)]
        public string FirstName { get; set; } = null!;
        [Column("last_name")]
        [StringLength(16)]
        public string LastName { get; set; } = null!;
        [Column("gender", TypeName = "enum('M','F')")]
        public string Gender { get; set; } = null!;
        [Column("hire_date")]
        public DateOnly HireDate { get; set; }

        [InverseProperty("EmpNoNavigation")]
        public ICollection<Job> DeptEmps { get; set; }
        [InverseProperty("EmpNoNavigation")]
        public ICollection<DeptManager> DeptManagers { get; set; }
        [InverseProperty("EmpNoNavigation")]
        public ICollection<Salary> Salaries { get; set; }
        [InverseProperty("EmpNoNavigation")]
        public ICollection<Title> Titles { get; set; }
    }
}
