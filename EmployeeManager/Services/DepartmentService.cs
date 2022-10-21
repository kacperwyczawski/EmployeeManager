using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services;

public class DepartmentService
{
    private readonly EmployeeManagerContext _context;

    public DepartmentService(EmployeeManagerContext context) =>
        _context = context;

    public async Task<List<Department>> GetDepartmentsAsync() =>
        await _context.Departments.ToListAsync();
}