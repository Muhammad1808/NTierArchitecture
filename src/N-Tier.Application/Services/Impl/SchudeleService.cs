using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Schudele;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ScheduleService : ISchudeleService
{
    private readonly ISchudeleRepository _repository;
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ISubjectRepository _subjectRepository;

    public ScheduleService(IMapper mapper, ISchudeleRepository repository, IGroupRepository groupRepository, IEmployeeRepository employeeRepository, ISubjectRepository subjectRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _groupRepository = groupRepository;
        _employeeRepository = employeeRepository;
        _subjectRepository = subjectRepository;
    }

    public async Task<CreateSchudeleResponseModel> CreateAsync(CreateSchudeleModel createScheduleModel, CancellationToken cancellationToken = default)
    {
        var group = await _groupRepository.GetFirstAsync(g => g.Id == createScheduleModel.GroupId);
        var employee=await _employeeRepository.GetFirstAsync(e=>e.Id == createScheduleModel.EmployeeId);
        var subject=await _subjectRepository.GetFirstAsync(s=>s.Id == createScheduleModel.SubjectId);
        var schedule = _mapper.Map<Schudele>(createScheduleModel);
        schedule.Group = group;
        schedule.Employee = employee;
        schedule.Subject = subject;
        var addedSchedule = await _repository.AddAsync(schedule);
        return new CreateSchudeleResponseModel
        {
            Id = addedSchedule.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var schedule = await _repository.GetFirstAsync(x => x.Id == id);
        if (schedule == null)
            throw new KeyNotFoundException("Schedule not found.");
        var deletedSchedule = await _repository.DeleteAsync(schedule);
        return new BaseResponseModel
        {
            Id = deletedSchedule.Id
        };
    }

    public async Task<IEnumerable<SchudeleResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var schedules = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<SchudeleResponseModel>>(schedules);
    }

    public async Task<UpdateSchudeleResponseModel> UpdateAsync(Guid id, UpdateSchudeleModel updateScheduleModel, CancellationToken cancellationToken = default)
    {
        var schedule = await _repository.GetFirstAsync(x => x.Id == id);
        if (schedule == null)
            throw new KeyNotFoundException("Schedule not found.");
        _mapper.Map(updateScheduleModel, schedule);
        var updatedSchedule = await _repository.UpdateAsync(schedule);
        return new UpdateSchudeleResponseModel
        {
            Id = updatedSchedule.Id
        };
    }
}
