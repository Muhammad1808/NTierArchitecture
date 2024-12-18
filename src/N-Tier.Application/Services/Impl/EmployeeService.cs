using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeService(IMapper mapper, IEmployeeRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel, CancellationToken cancellationToken = default)
    {
        var employee = _mapper.Map<Employee>(createEmployeeModel);

        var addedEmployee = await _repository.AddAsync(employee);

        return new CreateEmployeeResponseModel
        {
            Id = addedEmployee.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employee = await _repository.GetFirstAsync(x => x.Id == id);
        if (employee == null)
            throw new KeyNotFoundException("Employee not found.");

        var deletedEmployee = await _repository.DeleteAsync(employee);

        return new BaseResponseModel
        {
            Id = deletedEmployee.Id
        };
    }

    public async Task<IEnumerable<EmployeeResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employees = await _repository.GetAllAsyncPerson(
        x => x.Id == id,
        include: q => q.Include(x => x.Person)
        );

        return _mapper.Map<IEnumerable<EmployeeResponseModel>>(employees);
    }

    public async Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel, CancellationToken cancellationToken = default)
    {
        var employee = await _repository.GetFirstAsync(x => x.Id == id);
        if (employee == null)
            throw new KeyNotFoundException("Employee not found.");

        _mapper.Map(updateEmployeeModel, employee);

        var updatedEmployee = await _repository.UpdateAsync(employee);

        return new UpdateEmployeeResponseModel
        {
            Id = updatedEmployee.Id
        };
    }
}
