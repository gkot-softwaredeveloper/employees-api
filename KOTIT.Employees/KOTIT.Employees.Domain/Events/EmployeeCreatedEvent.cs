namespace KOTIT.Employees.Domain.Events;

public class EmployeeCreatedEvent
{
    public int EmployeeId { get; }
    public string FirstName { get; } = null!;
    public string LastName { get; } = null!;
    public DateTime BirthDate { get; }
    public DateTime CreatedDate { get; }

    public EmployeeCreatedEvent(int employeeId, string firstName, string lastName, DateTime birthDate)
    {
        EmployeeId = employeeId;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        CreatedDate = DateTime.UtcNow;
    }
}
