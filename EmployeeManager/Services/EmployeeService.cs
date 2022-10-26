using EmployeeManager.Data;
using EmployeeManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services;

public class EmployeeService
{
    private readonly EmployeeManagerContext _context;
    private readonly DepartmentService _departmentService;
    private readonly TitleService _titleService;
    private readonly SalaryService _salaryService;
    private readonly AppState _appState;

    public EmployeeService(EmployeeManagerContext context, DepartmentService departmentService,
        TitleService titleService, SalaryService salaryService, AppState appState)
    {
        _context = context;
        _departmentService = departmentService;
        _titleService = titleService;
        _salaryService = salaryService;
        _appState = appState;
    }

    public IEnumerable<EmployeeView> GetEmployees()
    {
        var amount = _appState.ItemsPerPage;

        var lastId = _appState.LastEmployeeId ?? 0;
        
        var employees = _context.Employees
            .AsNoTracking()
            .OrderBy(e => e.EmpNo)
            .Where(e => e.EmpNo > lastId);

        if (_appState.GenderFilter.IsActive)
            employees = employees.Where(e =>
                e.Gender[0] == _appState.GenderFilter.AllowedValue);

        if (_appState.DepartmentFilter.IsActive)
            employees = employees.Where(e =>
                _departmentService.GetDepartmentName(e.EmpNo) == _appState.DepartmentFilter.AllowedValue);

        if (_appState.SalaryFilter.IsActive)
            employees = employees.Where(e =>
                _salaryService.GetSalaryValue(e.EmpNo) >= _appState.SalaryFilter.AllowedValue.From &&
                _salaryService.GetSalaryValue(e.EmpNo) <= _appState.SalaryFilter.AllowedValue.To);

        employees = employees.Take(amount);
        
        _appState.LastEmployeeId = employees.Last().EmpNo;
        
        return employees.ToList().Select(e => new EmployeeView(
            FirstName: e.FirstName,
            LastName: e.LastName,
            IsMale: e.Gender == "M",
            DepartmentName: _departmentService.GetDepartmentName(e.EmpNo),
            JobTitle: _titleService.GetTitleName(e.EmpNo),
            Salary: _salaryService.GetSalaryValue(e.EmpNo)
        ));
    }

    public int GetEmployeesCount() => _context.Employees.Count();
}