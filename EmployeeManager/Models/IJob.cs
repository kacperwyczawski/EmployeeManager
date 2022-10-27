namespace EmployeeManager.Models;

public interface IJob
{
    int EmpNo { get; set; }
    string DeptNo { get; set; }
    DateOnly FromDate { get; set; }
    DateOnly ToDate { get; set; }
    Department DeptNoNavigation { get; set; }
    Employee EmpNoNavigation { get; set; }
}