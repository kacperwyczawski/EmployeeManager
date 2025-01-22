using EmployeeManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Services;

public class TitleService
{
    private readonly EmployeeManagerContext _context;

    public TitleService(EmployeeManagerContext context) =>
        _context = context;
    
    public string GetTitleName(int employeeId)
    {
        var titles = _context.Titles
            .AsNoTracking()
            .Where(t => t.EmpNo == employeeId);

        return titles.SingleOrDefault(t => t.ToDate == null)?.Title1
            ?? titles.OrderByDescending(t => t.ToDate).First().Title1;
    }
}