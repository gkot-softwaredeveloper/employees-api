﻿namespace KOTIT.Employees.Application.Dtos;

public class EmployeeRequestDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}
