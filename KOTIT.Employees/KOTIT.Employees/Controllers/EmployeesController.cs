using KOTIT.Employees.Application.Dtos;
using KOTIT.Employees.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KOTIT.Employees.Infrastructure.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly IMediator _mbus;
    public EmployeesController(ILogger<EmployeesController> logger, IMediator mbus)
    {
        _logger = logger;
        _mbus = mbus;
    }

    [HttpGet]
    public async Task<IEnumerable<EmployeeDto>> GetEmployees(CancellationToken ct)
    {
        _logger.LogInformation("Getting employees");

        return await _mbus.Send(new GetEmployeesQuery(), ct);
    }
}