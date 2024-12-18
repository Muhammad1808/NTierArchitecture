using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Event;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class EventService : IEventService
{
    private readonly IEventRepository _repository;
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public EventService(IMapper mapper, IEventRepository repository, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateEventResponseModel> CreateAsync(CreateEventModel createEventModel, CancellationToken cancellationToken = default)
    {
        var student = await _studentRepository.GetFirstAsync(s => s.Id == createEventModel.StudentId);
        var eventEntity = _mapper.Map<Event>(createEventModel);
        eventEntity.Student=student;
        var addedEvent = await _repository.AddAsync(eventEntity);
        return new CreateEventResponseModel
        {
            Id = addedEvent.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var eventEntity = await _repository.GetFirstAsync(x => x.Id == id);
        if (eventEntity == null)
            throw new KeyNotFoundException("Event not found.");
        var deletedEvent = await _repository.DeleteAsync(eventEntity);
        return new BaseResponseModel
        {
            Id = deletedEvent.Id
        };
    }

    public async Task<IEnumerable<EventResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var events = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<EventResponseModel>>(events);
    }

    public async Task<UpdateEventResponseModel> UpdateAsync(Guid id, UpdateEventModel updateEventModel, CancellationToken cancellationToken = default)
    {
        var eventEntity = await _repository.GetFirstAsync(x => x.Id == id);
        if (eventEntity == null)
            throw new KeyNotFoundException("Event not found.");
        _mapper.Map(updateEventModel, eventEntity);
        var updatedEvent = await _repository.UpdateAsync(eventEntity);
        return new UpdateEventResponseModel
        {
            Id = updatedEvent.Id
        };
    }
}
