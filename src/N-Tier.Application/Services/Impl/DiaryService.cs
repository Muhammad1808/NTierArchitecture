using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Diary;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class DiaryService : IDiaryService
{
    private readonly IDiaryRepository _repository;
    private readonly IMapper _mapper;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IStudentRepository _studentRepository;

    public DiaryService(IMapper mapper, IDiaryRepository repository, ISubjectRepository subjectRepository, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _subjectRepository = subjectRepository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateDiaryResponseModel> CreateAsync(CreateDiaryModel createDiaryModel, CancellationToken cancellationToken = default)
    {
        var subject=await _subjectRepository.GetFirstAsync(s=>s.Id==createDiaryModel.SubjectId);
        var student=await _studentRepository.GetFirstAsync(s=>s.Id==createDiaryModel.StudentId);
        var diary = _mapper.Map<Diary>(createDiaryModel);
        diary.Subject = subject;
        diary.Student = student;
        var addedDiary = await _repository.AddAsync(diary);
        return new CreateDiaryResponseModel
        {
            Id = addedDiary.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var diary = await _repository.GetFirstAsync(x => x.Id == id);
        if (diary == null)
            throw new KeyNotFoundException("Diary not found.");
        var deletedDiary = await _repository.DeleteAsync(diary);
        return new BaseResponseModel
        {
            Id = deletedDiary.Id
        };
    }

    public async Task<IEnumerable<DiaryResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var diaries = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<DiaryResponseModel>>(diaries);
    }

    public async Task<UpdateDiaryResponseModel> UpdateAsync(Guid id, UpdateDiaryModel updateDiaryModel, CancellationToken cancellationToken = default)
    {
        var diary = await _repository.GetFirstAsync(x => x.Id == id);
        if (diary == null)
            throw new KeyNotFoundException("Diary not found.");
        _mapper.Map(updateDiaryModel, diary);
        var updatedDiary = await _repository.UpdateAsync(diary);
        return new UpdateDiaryResponseModel
        {
            Id = updatedDiary.Id
        };
    }
}
