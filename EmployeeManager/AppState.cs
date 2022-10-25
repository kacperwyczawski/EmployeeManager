namespace EmployeeManager;

public class AppState
{
    public int ItemsPerPage { get; set; } = 20;
    
    public void ResetToDefaults()
    {
        ItemsPerPage = 20;
    }
}