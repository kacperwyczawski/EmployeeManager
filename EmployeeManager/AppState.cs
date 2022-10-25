namespace EmployeeManager;

public class AppState
{
    public AppState() => ResetToDefaults();

    public int ItemsPerPage { get; set; }
    
    public GenderFilter Gender { get; set; }
    
    public (int from, int to)? SalaryRange { get; set; }
    
    public string? DepartmentName { get; set; }
    
    public void ResetToDefaults()
    {
        ItemsPerPage = 20;
        Gender = GenderFilter.Any;
        SalaryRange = null;
        DepartmentName = null;
    }

    public enum GenderFilter
    {
        Any, Male, Female
    }
}