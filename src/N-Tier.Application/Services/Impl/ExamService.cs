using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Exam;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ExamService : IExamService
{
    private readonly IExamRepository _repository;
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IRoomRepository _roomRepository;

    public ExamService(IMapper mapper, IExamRepository repository, IGroupRepository groupRepository, ISubjectRepository subjectRepository, IRoomRepository roomRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _groupRepository = groupRepository;
        _subjectRepository = subjectRepository;
        _roomRepository = roomRepository;
    }

    public async Task<CreateExamResponseModel> CreateAsync(CreateExamModel createExamModel, CancellationToken cancellationToken = default)
    {
        var group = await _groupRepository.GetFirstAsync(g => g.Id == createExamModel.GroupId);
        var subject=await _subjectRepository.GetFirstAsync(s=>s.Id == createExamModel.SubjectId);
        var room=await _roomRepository.GetFirstAsync(r=>r.Id == createExamModel.RoomId);
        var exam = _mapper.Map<Exam>(createExamModel);
        exam.Group = group;
        exam.Subject = subject;
        exam.Room = room;
        var addedExam = await _repository.AddAsync(exam);
        return new CreateExamResponseModel
        {
            Id = addedExam.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var exam = await _repository.GetFirstAsync(x => x.Id == id);
        if (exam == null)
            throw new KeyNotFoundException("Exam not found.");
        var deletedExam = await _repository.DeleteAsync(exam);
        return new BaseResponseModel
        {
            Id = deletedExam.Id
        };
    }

    public async Task<IEnumerable<ExamResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var exams = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<ExamResponseModel>>(exams);
    }

    public async Task<UpdateExamResponseModel> UpdateAsync(Guid id, UpdateExamModel updateExamModel, CancellationToken cancellationToken = default)
    {
        var exam = await _repository.GetFirstAsync(x => x.Id == id);
        if (exam == null)
            throw new KeyNotFoundException("Exam not found.");
        _mapper.Map(updateExamModel, exam);
        var updatedExam = await _repository.UpdateAsync(exam);
        return new UpdateExamResponseModel
        {
            Id = updatedExam.Id
        };
    }
}
