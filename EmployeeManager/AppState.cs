namespace EmployeeManager;

public class AppState
{
    private readonly ILogger<AppState> _logger;
    
    private int? _lastEmployeeId;

    public AppState(ILogger<AppState> logger)
    {
        _logger = logger;
        ResetToDefaults();
    }

    public int ItemsPerPage { get; set; }

    /// <summary>
    /// Used for keyset pagination,
    /// setting this value will cause incrementing the page number (except setting it to null)
    /// </summary>
    public int? LastEmployeeId
    {
        get => _lastEmployeeId;
        set
        {
            if (value is not null)
                Page++;
            
            _lastEmployeeId = value;
        }
    }

    /// <summary>
    /// Indicates the current page number, 0 means there is no employees loaded, 1 is the first page
    /// </summary>
    public int Page { get; private set; }

    public Filter<string> GenderFilter { get; set; } = new("M");

    public Filter<string> DepartmentFilter { get; set; } = new("d009");

    public Filter<SalaryRange> SalaryFilter { get; set; } = new(new SalaryRange(60_000, 70_000));

    /// <summary>
    /// If true, only current employees are allowed, otherwise only former employees are allowed
    /// </summary>
    public Filter<bool> CurrentEmployeeFilter { get; set; } = new(true);

    public event Action? OnFiltersChange;
    
    public void GoToFirstPage()
    {
        LastEmployeeId = null;
        Page = 0;
    }

    public void ResetToDefaults()
    {
        ItemsPerPage = 20;
        GenderFilter.IsActive = false;
        DepartmentFilter.IsActive = false;
        SalaryFilter.IsActive = false;
        CurrentEmployeeFilter.IsActive = false;
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

    public void NotifyFiltersChanged()
    {
        _logger.LogInformation("Invoking " + nameof(OnFiltersChange));
        OnFiltersChange?.Invoke();
    }

    public class SalaryRange
    {
        private int _from;
        private int _to;

        public SalaryRange(int from, int to)
        {
            From = from;
            To = to;
        }

        public int From
        {
            get => _from;
            set
            {
                if (value > To)
                    To = value;

                _from = value;
            }
        }

        public int To
        {
            get => _to;
            set
            {
                if (value < From)
                    From = value;

                _to = value;
            }
        }

        public override string ToString() => $"{From} - {To}";
    }
}