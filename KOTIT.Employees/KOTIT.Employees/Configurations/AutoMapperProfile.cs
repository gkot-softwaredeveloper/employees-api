using AutoMapper;
using KOTIT.Employees.Application.Commands;
using KOTIT.Employees.Application.Dtos;
using KOTIT.Employees.Domain.Entities;

namespace KOTIT.Employees.Infrastructure.Host.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Employee, EmployeeResponseDto>()
            .ReverseMap()
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedDate, opt => opt.Ignore());

        CreateMap<CreateEmployeeCommand, Employee>()
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedDate, opt => opt.Ignore());

        CreateMap<EmployeeRequestDto, CreateEmployeeCommand>();
    }
}
