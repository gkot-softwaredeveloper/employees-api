using AutoMapper;
using KOTIT.Employees.Application.Dtos;
using KOTIT.Employees.Domain.Entities;
using KOTIT.Employees.Domain.Repositories;
using MediatR;

namespace KOTIT.Employees.Application.Queries;

public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeResponseDto>>
{
}

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeResponseDto>>
{
    private readonly IRepository<Employee> _repository;
    private readonly IMapper _mapper;

    public GetEmployeesQueryHandler(IRepository<Employee> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<EmployeeResponseDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync();
        var response = _mapper.Map<IEnumerable<EmployeeResponseDto>>(result);
        return response;
    }
}
