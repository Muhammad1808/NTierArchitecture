using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Lesson;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IRoomRepository _roomRepository;

    public LessonService(IMapper mapper, ILessonRepository repository, IEmployeeRepository employeeRepository, IGroupRepository groupRepository, ISubjectRepository subjectRepository, IRoomRepository roomRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _employeeRepository = employeeRepository;
        _groupRepository = groupRepository;
        _subjectRepository = subjectRepository;
        _roomRepository = roomRepository;
    }

    public async Task<CreateLessonResponseModel> CreateAsync(CreateLessonModel createLessonModel, CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetFirstAsync(e => e.Id == createLessonModel.EmployeeId);
        var group = await _groupRepository.GetFirstAsync(g => g.Id == createLessonModel.GroupId);
        var subject = await _subjectRepository.GetFirstAsync(s => s.Id == createLessonModel.SubjectId);
        var room = await _roomRepository.GetFirstAsync(r => r.Id == createLessonModel.RoomId);
        var lesson = _mapper.Map<Lesson>(createLessonModel);
        lesson.Employee = employee;
        lesson.Group = group;
        lesson.Subject = subject;
        lesson.Room = room;
        var addedLesson = await _repository.AddAsync(lesson);
        return new CreateLessonResponseModel
        {
            Id = addedLesson.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var lesson = await _repository.GetFirstAsync(x => x.Id == id);
        if (lesson == null)
            throw new KeyNotFoundException("Lesson not found.");
        var deletedLesson = await _repository.DeleteAsync(lesson);
        return new BaseResponseModel
        {
            Id = deletedLesson.Id
        };
    }

    public async Task<IEnumerable<LessonResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var lessons = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<LessonResponseModel>>(lessons);
    }

    public async Task<UpdateLessonResponseModel> UpdateAsync(Guid id, UpdateLessonModel updateLessonModel, CancellationToken cancellationToken = default)
    {
        var lesson = await _repository.GetFirstAsync(x => x.Id == id);
        if (lesson == null)
            throw new KeyNotFoundException("Lesson not found.");
        _mapper.Map(updateLessonModel, lesson);
        var updatedLesson = await _repository.UpdateAsync(lesson);
        return new UpdateLessonResponseModel
        {
            Id = updatedLesson.Id
        };
    }
}
