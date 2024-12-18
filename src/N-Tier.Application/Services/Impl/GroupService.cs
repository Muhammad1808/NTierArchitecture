using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Group;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _repository;
    private readonly IMapper _mapper;

    public GroupService(IMapper mapper, IGroupRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateGroupResponseModel> CreateAsync(CreateGroupModel createGroupModel, CancellationToken cancellationToken = default)
    {
        var group = _mapper.Map<Group>(createGroupModel);
        var addedGroup = await _repository.AddAsync(group);
        return new CreateGroupResponseModel
        {
            Id = addedGroup.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var group = await _repository.GetFirstAsync(x => x.Id == id);
        if (group == null)
            throw new KeyNotFoundException("Group not found.");
        var deletedGroup = await _repository.DeleteAsync(group);
        return new BaseResponseModel
        {
            Id = deletedGroup.Id
        };
    }

    public async Task<IEnumerable<GroupResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var groups = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<GroupResponseModel>>(groups);
    }

    public async Task<UpdateGroupResponseModel> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel, CancellationToken cancellationToken = default)
    {
        var group = await _repository.GetFirstAsync(x => x.Id == id);
        if (group == null)
            throw new KeyNotFoundException("Group not found.");
        _mapper.Map(updateGroupModel, group);
        var updatedGroup = await _repository.UpdateAsync(group);
        return new UpdateGroupResponseModel
        {
            Id = updatedGroup.Id
        };
    }
}
