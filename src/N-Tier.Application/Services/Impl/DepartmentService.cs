using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Department;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;
    private readonly IMapper _mapper;
    private readonly IAboutSchoolRepository _aboutSchoolRepository;

    public DepartmentService(IMapper mapper, IDepartmentRepository repository, IAboutSchoolRepository aboutSchoolRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _aboutSchoolRepository = aboutSchoolRepository;
    }

    public async Task<CreateDepartmentResponseModel> CreateAsync(CreateDepartmentModel createDepartmentModel, CancellationToken cancellationToken = default)
    {
        var school = await _aboutSchoolRepository.GetFirstAsync(s => s.Id == createDepartmentModel.AboutSchoolId);
        var department = _mapper.Map<Department>(createDepartmentModel);
        department.AboutSchool = school;
        var addedDepartment = await _repository.AddAsync(department);
        return new CreateDepartmentResponseModel
        {
            Id = addedDepartment.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var department = await _repository.GetFirstAsync(x => x.Id == id);
        if (department == null)
            throw new KeyNotFoundException("Department not found.");
        var deletedDepartment = await _repository.DeleteAsync(department);
        return new BaseResponseModel
        {
            Id = deletedDepartment.Id
        };
    }

    public async Task<IEnumerable<DepartmentResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var departments = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<DepartmentResponseModel>>(departments);
    }

    public async Task<UpdateDepartmentResponseModel> UpdateAsync(Guid id, UpdateDepartmentModel updateDepartmentModel, CancellationToken cancellationToken = default)
    {
        var department = await _repository.GetFirstAsync(x => x.Id == id);
        if (department == null)
            throw new KeyNotFoundException("Department not found.");
        _mapper.Map(updateDepartmentModel, department);
        var updatedDepartment = await _repository.UpdateAsync(department);
        return new UpdateDepartmentResponseModel
        {
            Id = updatedDepartment.Id
        };
    }
}
