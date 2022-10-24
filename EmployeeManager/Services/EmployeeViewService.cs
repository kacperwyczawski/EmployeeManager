using EmployeeManager.Data;
using EmployeeManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services;

public class EmployeeViewService
{
    private readonly EmployeeManagerContext _context;

    private readonly DepartmentService _departmentService;

    private readonly TitleService _titleService;
    
    private readonly SalaryService _salaryService;

    public EmployeeViewService(EmployeeManagerContext context, DepartmentService departmentService,
        TitleService titleService, SalaryService salaryService)
    {
        _context = context;
        _departmentService = departmentService;
        _titleService = titleService;
        _salaryService = salaryService;
    }

    public IEnumerable<EmployeeView> GetEmployees(int skip, int take)
    {
        var employees = _context.Employees
            .AsNoTracking()
            .AsEnumerable()
            .OrderBy(e => e.EmpNo)
            .Skip(skip)
            .Take(take);

        foreach (var employee in employees)
        {
            yield return new EmployeeView(
                FirstName: employee.FirstName,
                LastName: employee.LastName,
                IsMale: employee.Gender == "M",
                DepartmentName: _departmentService.GetDepartmentName(employee.EmpNo),
                JobTitle: _titleService.GetTitleName(employee.EmpNo),
                Salary: _salaryService.GetSalaryValue(employee.EmpNo)
            );
        }
    }
}