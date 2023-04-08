using AutoMapper;
using KOTIT.Employees.Domain.Entities;
using KOTIT.Employees.Domain.Repositories;
using MediatR;

namespace KOTIT.Employees.Application.Commands;

public class CreateEmployeeCommand : IRequest<int>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IRepository<Employee> _repository;
    private readonly IMapper _mapper;
    public CreateEmployeeCommandHandler(IRepository<Employee> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await _repository.AddAsync(_mapper.Map<Employee>(request));
    }
}
