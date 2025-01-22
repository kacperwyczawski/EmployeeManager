using EmployeeManager.Data;
using MudBlazor;

namespace EmployeeManager.Services;

public class SalaryService
{
    private readonly EmployeeManagerContext _context;

    public SalaryService(EmployeeManagerContext context) => _context = context;

    public int GetSumOfSalaries(int employeeId) => _context.Salaries
        .Where(s => s.EmpNo == employeeId)
        .Sum(s => s.Salary1);
}