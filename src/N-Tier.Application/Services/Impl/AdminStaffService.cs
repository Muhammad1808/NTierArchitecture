using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Models;
using N_Tier.Application.Models.AdminStaff;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class AdminStaffService : IAdminStaffService
{
    private readonly IAdminStaffRepository _repository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public AdminStaffService(IMapper mapper, IAdminStaffRepository repository,IDepartmentRepository departmentRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _departmentRepository = departmentRepository;
    }

    public async Task<CreateAdminStaffResponseModel> CreateAsync(CreateAdminStaffModel createAdminStaffModel, CancellationToken cancellationToken = default)
    {
        var department = await _departmentRepository.GetFirstAsync(d => d.Id == createAdminStaffModel.DepartmentId);
        var adminStaff = _mapper.Map<AdminStaff>(createAdminStaffModel); 
        adminStaff.Department= department;
        var addedAdminStaff = await _repository.AddAsync(adminStaff);
        return new CreateAdminStaffResponseModel
        {
            Id = addedAdminStaff.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var adminStaff = await _repository.GetFirstAsync(x => x.Id == id);
        if (adminStaff == null)
            throw new KeyNotFoundException("AdminStaff not found.");
        var deletedAdminStaff = await _repository.DeleteAsync(adminStaff);
        return new BaseResponseModel
        {
            Id = deletedAdminStaff.Id
        };
    }

    public async Task<IEnumerable<AdminStaffResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var adminStaffs = await _repository.GetAllAsyncPerson(
        x => x.Id == id,
        include: q => q.Include(x => x.Person)
        );
        return _mapper.Map<IEnumerable<AdminStaffResponseModel>>(adminStaffs);
    }

    public async Task<UpdateAdminStaffResponseModel> UpdateAsync(Guid id, UpdateAdminStaffModel updateAdminStaffModel, CancellationToken cancellationToken = default)
    {
        var adminStaff = await _repository.GetFirstAsync(x => x.Id == id);
        if (adminStaff == null)
            throw new KeyNotFoundException("AdminStaff not found.");
        _mapper.Map(updateAdminStaffModel, adminStaff);
        var updatedAdminStaff = await _repository.UpdateAsync(adminStaff);
        return new UpdateAdminStaffResponseModel
        {
            Id = updatedAdminStaff.Id
        };
    }
}
