using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services;

public class EmployeeService
{
    private readonly EmployeeManagerContext _context;

    public EmployeeService(EmployeeManagerContext context) =>
        _context = context;

    public async Task<List<Employee>> GetEmployeesAsync() =>
        await _context.Employees.AsNoTracking().ToListAsync();
}