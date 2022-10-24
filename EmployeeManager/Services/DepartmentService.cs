using EmployeeManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services;

public class DepartmentService
{
    private readonly EmployeeManagerContext _context;

    public DepartmentService(EmployeeManagerContext context) =>
        _context = context;

    public string GetDepartmentName(int employeeId)
    {
        var recentlyEmployeeAt = _context.DeptEmps
            .AsNoTracking()
            .Include(de => de.DeptNoNavigation)
            .Where(de => de.EmpNo == employeeId)
            .OrderByDescending(de => de.ToDate)
            .FirstOrDefault();

        var recentlyManagerAt = _context.DeptManagers
            .AsNoTracking()
            .Include(de => de.DeptNoNavigation)
            .Where(dm => dm.EmpNo == employeeId)
            .OrderByDescending(dm => dm.ToDate)
            .FirstOrDefault();

        if (recentlyEmployeeAt is null && recentlyManagerAt is not null)
            return recentlyManagerAt.DeptNoNavigation.DeptName;

        if (recentlyEmployeeAt is not null && recentlyManagerAt is null)
            return recentlyEmployeeAt.DeptNoNavigation.DeptName;
        
        if (recentlyEmployeeAt is not null && recentlyManagerAt is not null)
            return recentlyEmployeeAt.ToDate > recentlyManagerAt.ToDate
                ? recentlyEmployeeAt.DeptNoNavigation.DeptName
                : recentlyManagerAt.DeptNoNavigation.DeptName;
        
        throw new InvalidOperationException("Employee is not assigned to any department.");
    }
}