using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Dormitory;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class DormitoryService : IDormitoryService
{
    private readonly IDormitoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IAboutSchoolRepository _aboutSchoolRepository;

    public DormitoryService(IMapper mapper, IDormitoryRepository repository,IAboutSchoolRepository aboutSchoolRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _aboutSchoolRepository = aboutSchoolRepository;
    }

    public async Task<CreateDormitoryResponseModel> CreateAsync(CreateDormitoryModel createDormitoryModel, CancellationToken cancellationToken = default)
    {
        var school = await _aboutSchoolRepository.GetFirstAsync(s => s.Id == createDormitoryModel.AboutSchoolId);
        var dormitory = _mapper.Map<Dormitory>(createDormitoryModel);
        dormitory.AboutSchool = school;
        var addedDormitory = await _repository.AddAsync(dormitory);
        return new CreateDormitoryResponseModel
        {
            Id = addedDormitory.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dormitory = await _repository.GetFirstAsync(x => x.Id == id);
        if (dormitory == null)
            throw new KeyNotFoundException("Dormitory not found.");
        var deletedDormitory = await _repository.DeleteAsync(dormitory);
        return new BaseResponseModel
        {
            Id = deletedDormitory.Id
        };
    }

    public async Task<IEnumerable<DormitoryResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dormitories = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<DormitoryResponseModel>>(dormitories);
    }

    public async Task<UpdateDormitoryResponseModel> UpdateAsync(Guid id, UpdateDormitoryModel updateDormitoryModel, CancellationToken cancellationToken = default)
    {
        var dormitory = await _repository.GetFirstAsync(x => x.Id == id);
        if (dormitory == null)
            throw new KeyNotFoundException("Dormitory not found.");
        _mapper.Map(updateDormitoryModel, dormitory);
        var updatedDormitory = await _repository.UpdateAsync(dormitory);
        return new UpdateDormitoryResponseModel
        {
            Id = updatedDormitory.Id
        };
    }
}
