using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.AboutSchool;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class AboutSchoolService : IAboutSchoolService
{
    private readonly IAboutSchoolRepository _repository;
    private readonly IMapper _mapper;

    public AboutSchoolService(IMapper mapper, IAboutSchoolRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateSchoolResponseModel> CreateAsync(CreateSchoolModel createAboutSchoolModel, CancellationToken cancellationToken = default)
    {
        var aboutSchool = _mapper.Map<AboutSchool>(createAboutSchoolModel);

        var addedAboutSchool = await _repository.AddAsync(aboutSchool);

        return new CreateSchoolResponseModel
        {
            Id = addedAboutSchool.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var aboutSchool = await _repository.GetFirstAsync(x => x.Id == id);
        if (aboutSchool == null)
            throw new KeyNotFoundException("AboutSchool not found.");

        var deletedAboutSchool = await _repository.DeleteAsync(aboutSchool);

        return new BaseResponseModel
        {
            Id = deletedAboutSchool.Id
        };
    }

    public async Task<IEnumerable<SchoolResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var aboutSchools = await _repository.GetAllAsync(x => x.Id == id);

        return _mapper.Map<IEnumerable<SchoolResponseModel>>(aboutSchools);
    }

    public async Task<UpdateSchoolResponseModel> UpdateAsync(Guid id, UpdateSchoolModel updateAboutSchoolModel, CancellationToken cancellationToken = default)
    {
        var aboutSchool = await _repository.GetFirstAsync(x => x.Id == id);
        if (aboutSchool == null)
            throw new KeyNotFoundException("AboutSchool not found.");

        _mapper.Map(updateAboutSchoolModel, aboutSchool);

        var updatedAboutSchool = await _repository.UpdateAsync(aboutSchool);

        return new UpdateSchoolResponseModel
        {
            Id = updatedAboutSchool.Id
        };
    }
}
