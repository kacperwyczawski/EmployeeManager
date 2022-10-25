namespace EmployeeManager;

public class AppState
{
    public int ItemsPerPage { get; set; } = 20;
    
    public GenderFilter Gender { get; set; }
    
    public void ResetToDefaults()
    {
        ItemsPerPage = 20;
        Gender = GenderFilter.Any;
    }

    public enum GenderFilter
    {
        Any, Male, Female
    }
}