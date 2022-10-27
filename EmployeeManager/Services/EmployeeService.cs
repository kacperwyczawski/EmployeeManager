using EmployeeManager.Data;
using EmployeeManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services;

public class EmployeeService
{
    private readonly EmployeeManagerContext _context;
    private readonly DepartmentService _departmentService;
    private readonly TitleService _titleService;
    private readonly AppState _appState;

    public EmployeeService(EmployeeManagerContext context, DepartmentService departmentService,
        TitleService titleService, AppState appState)
    {
        _context = context;
        _departmentService = departmentService;
        _titleService = titleService;
        _appState = appState;
    }

    public IEnumerable<EmployeeView> GetEmployees()
    {
        var amount = _appState.ItemsPerPage;

        var lastId = _appState.LastEmployeeId ?? 0;
        
        var infiniteDate = new DateOnly(9999, 1, 1);

        var employees = _context.Employees
            .AsNoTracking()
            .OrderBy(e => e.EmpNo)
            .Where(e => e.EmpNo > lastId)
            .Include(e => e.Salaries)
            .Include(e => e.DeptEmps)
            .ThenInclude(de => de.DeptNoNavigation)
            .Include(e => e.DeptManagers)
            .ThenInclude(dm => dm.DeptNoNavigation)
            .AsQueryable();

        // gender filter
        if (_appState.GenderFilter.GetAllowedValue(out var allowedGender))
            employees = employees.Where(e =>
                e.Gender == allowedGender);

        // department filter
        if (_appState.DepartmentFilter.GetAllowedValue(out var allowedDepartment))
            employees = employees.Where(e =>
                (e.DeptEmps.OrderByDescending(de => de.ToDate).Any()
                 && e.DeptEmps.OrderByDescending(de => de.ToDate).First().DeptNo == allowedDepartment)
                || // employee can be manager or just employee in department
                (e.DeptManagers.OrderByDescending(dm => dm.ToDate).Any()
                 && e.DeptManagers.OrderByDescending(dm => dm.ToDate).First().DeptNo == allowedDepartment));

        // salary filter
        if (_appState.SalaryFilter.GetAllowedValue(out var allowedSalary))
            employees = employees.Where(e =>
                e.Salaries.OrderByDescending(s => s.ToDate).First().Salary1 >= allowedSalary.From &&
                e.Salaries.OrderByDescending(s => s.ToDate).First().Salary1 <= allowedSalary.To);
        
        // current employee filter
        if (_appState.CurrentEmployeeFilter.GetAllowedValue(out var isCurrentEmployee))
            employees = employees.Where(e => 
                // ReSharper disable once ArrangeRedundantParentheses
                (e.Salaries.OrderByDescending(s => s.ToDate).First().ToDate == infiniteDate) == isCurrentEmployee);

        employees = employees.Take(amount);

        _appState.LastEmployeeId = employees.LastOrDefault()?.EmpNo;

        return employees.ToList().Select(e => new EmployeeView(
            FirstName: e.FirstName,
            LastName: e.LastName,
            IsMale: e.Gender == "M",
            DepartmentName: e.DeptEmps.Any()
                ? e.DeptEmps.OrderByDescending(de => de.ToDate).First().DeptNoNavigation.DeptName
                : e.DeptManagers.OrderByDescending(dm => dm.ToDate).First().DeptNoNavigation.DeptName,
            JobTitle: _titleService.GetTitleName(e.EmpNo),
            Salary: e.Salaries.OrderByDescending(s => s.ToDate).First().Salary1,
            IsCurrentEmployee: e.Salaries.OrderByDescending(s => s.ToDate).First().ToDate == infiniteDate,
            Id: e.EmpNo
        ));
    }

    public int GetEmployeesCount() => _context.Employees.Count();
}