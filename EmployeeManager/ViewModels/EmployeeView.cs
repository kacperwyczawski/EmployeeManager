namespace EmployeeManager.ViewModels;

public record EmployeeView(
    int Id,
    string FirstName,
    string LastName,
    string DepartmentName,
    string JobTitle,
    int Salary,
    bool IsMale);