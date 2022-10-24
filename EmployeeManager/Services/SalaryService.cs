using EmployeeManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services;

public class SalaryService
{
    private readonly EmployeeManagerContext _context;

    public SalaryService(EmployeeManagerContext context) => 
        _context = context;

    public int GetSalaryValue(int employeeId) =>
        _context.Salaries
            .AsNoTracking()
            .Where(s => s.EmpNo == employeeId)
            .OrderByDescending(s => s.ToDate)
            .First()
            .Salary1;
}