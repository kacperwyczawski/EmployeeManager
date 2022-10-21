using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Extensions;

namespace EmployeeManager.Services;

public class SalaryService
{
    private readonly EmployeeManagerContext _context;

    public SalaryService(EmployeeManagerContext context) => 
        _context = context;

    public Salary? GetRecentSalary(int employeeId) =>
        _context.Salaries
            .AsNoTracking()
            .Where(salary => salary.EmpNo == employeeId)
            .AsEnumerable()
            .MaxBy(salary => salary.ToDate);
}