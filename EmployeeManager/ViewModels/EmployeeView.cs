namespace EmployeeManager.ViewModels;

public record EmployeeView(
    string FirstName,
    string LastName,
    string DepartmentName,
    string JobTitle,
    int Salary,
    bool IsMale,
    bool IsCurrentEmployee,
    int Id);