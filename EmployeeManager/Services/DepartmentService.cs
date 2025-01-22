using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services;

public class DepartmentService
{
    private readonly EmployeeManagerContext _context;

    public DepartmentService(EmployeeManagerContext context) =>
        _context = context;

    public List<Department> GetDepartments() =>
        _context.Departments.AsNoTracking().ToList();
    
    public Department? GetDepartment(string id) =>
        _context.Departments.AsNoTracking().FirstOrDefault(d => d.DeptNo == id);
}