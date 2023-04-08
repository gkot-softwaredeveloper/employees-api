using AutoMapper;
using KOTIT.Employees.Application.Commands;
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
    private readonly IMapper _mapper;
    private readonly IMediator _mbus;
    public EmployeesController(ILogger<EmployeesController> logger, IMediator mbus, IMapper mapper)
    {
        _logger = logger;
        _mbus = mbus;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<EmployeeResponseDto>> GetEmployees(CancellationToken ct)
    {
        _logger.LogInformation("Getting employees");

        return await _mbus.Send(new GetEmployeesQuery(), ct);
    }

    [HttpPost]
    public async Task<int> CreateEmpoyee([FromBody] EmployeeRequestDto employee)
    {
        _logger.LogInformation("Creating employee");

        var command = _mapper.Map<CreateEmployeeCommand>(employee);
        return await _mbus.Send(command);
    }
}