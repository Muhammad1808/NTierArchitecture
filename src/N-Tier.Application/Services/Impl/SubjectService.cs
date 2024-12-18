using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Subject;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _repository;
    private readonly IMapper _mapper;

    public SubjectService(IMapper mapper, ISubjectRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateSubjectResponseModel> CreateAsync(CreateSubjectModel createSubjectModel, CancellationToken cancellationToken = default)
    {
        var subject = _mapper.Map<Subject>(createSubjectModel);
        var addedSubject = await _repository.AddAsync(subject);
        return new CreateSubjectResponseModel
        {
            Id = addedSubject.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var subject = await _repository.GetFirstAsync(x => x.Id == id);
        if (subject == null)
            throw new KeyNotFoundException("Subject not found.");
        var deletedSubject = await _repository.DeleteAsync(subject);
        return new BaseResponseModel
        {
            Id = deletedSubject.Id
        };
    }

    public async Task<IEnumerable<SubjectResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var subjects = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<SubjectResponseModel>>(subjects);
    }

    public async Task<UpdateSubjectResponseModel> UpdateAsync(Guid id, UpdateSubjectModel updateSubjectModel, CancellationToken cancellationToken = default)
    {
        var subject = await _repository.GetFirstAsync(x => x.Id == id);
        if (subject == null)
            throw new KeyNotFoundException("Subject not found.");
        _mapper.Map(updateSubjectModel, subject);
        var updatedSubject = await _repository.UpdateAsync(subject);
        return new UpdateSubjectResponseModel
        {
            Id = updatedSubject.Id
        };
    }
}
