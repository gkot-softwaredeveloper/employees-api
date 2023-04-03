using Microsoft.AspNetCore.Mvc;

namespace KOTIT.Employees.Application.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _logger;
    public EmployeesController(ILogger<EmployeesController> logger)
    {
        _logger = logger;
    }
}