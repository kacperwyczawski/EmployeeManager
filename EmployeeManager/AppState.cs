namespace EmployeeManager;

public class AppState
{
    public AppState()
    {
        ResetToDefaults();
    }

    public int ItemsPerPage { get; set; }

    public Filter<char> GenderFilter { get; set; } = new('M');

    public Filter<string> DepartmentFilter { get; set; } = new("Customer Service");
    
    public Filter<(int from, int to)> SalaryFilter { get; set; } = new ((12000, 18000));
    
    public void ResetToDefaults()
    {
        ItemsPerPage = 20;
        GenderFilter.IsActive = false;
        DepartmentFilter.IsActive = false;
        SalaryFilter.IsActive = false;
    }

    public class Filter<T>
    {
        public Filter(T allowedValue, bool isActive = false)
        {
            AllowedValue = allowedValue;
            IsActive = isActive;
        }

        public T AllowedValue { get; set; }
        
        public bool IsActive;
        
        public bool GetAllowedValue(out T value)
        {
            if (IsActive)
            {
                value = AllowedValue!;
                return true;
            }

            value = default!;
            return false;
        }
    }
}