using KOTIT.Employees.Application.Dtos;
using MediatR;

namespace KOTIT.Employees.Application.Queries;

public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
{
}

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{
    public Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
