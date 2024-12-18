using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Attendance;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILessonRepository _lessonRepository;

    public AttendanceService(IMapper mapper, IAttendanceRepository repository, ILessonRepository lessonRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _lessonRepository = lessonRepository;
    }

    public async Task<CreateAttendanceResponseModel> CreateAsync(CreateAttendanceModel createAttendanceModel, CancellationToken cancellationToken = default)
    {
        var lesson=await _lessonRepository.GetFirstAsync(l=>l.Id==createAttendanceModel.LessonId);
        var attendance = _mapper.Map<Attendance>(createAttendanceModel);
        attendance.Lesson=lesson;
        var addedAttendance = await _repository.AddAsync(attendance);
        return new CreateAttendanceResponseModel
        {
            Id = addedAttendance.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var attendance = await _repository.GetFirstAsync(x => x.Id == id);
        if (attendance == null)
            throw new KeyNotFoundException("Attendance not found.");
        var deletedAttendance = await _repository.DeleteAsync(attendance);
        return new BaseResponseModel
        {
            Id = deletedAttendance.Id
        };
    }

    public async Task<IEnumerable<AttendanceResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var attendances = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<AttendanceResponseModel>>(attendances);
    }

    public async Task<UpdateAttendanceResponseModel> UpdateAsync(Guid id, UpdateAttendanceModel updateAttendanceModel, CancellationToken cancellationToken = default)
    {
        var attendance = await _repository.GetFirstAsync(x => x.Id == id);
        if (attendance == null)
            throw new KeyNotFoundException("Attendance not found.");
        _mapper.Map(updateAttendanceModel, attendance);
        var updatedAttendance = await _repository.UpdateAsync(attendance);
        return new UpdateAttendanceResponseModel
        {
            Id = updatedAttendance.Id
        };
    }
}
