using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Parent;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ParentService : IParentService
{
    private readonly IParentRepository _repository;
    private readonly IMapper _mapper;

    public ParentService(IMapper mapper, IParentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateParentResponseModel> CreateAsync(CreateParentModel createParentModel, CancellationToken cancellationToken = default)
    {
        var parent = _mapper.Map<Parent>(createParentModel);
        var addedParent = await _repository.AddAsync(parent);
        return new CreateParentResponseModel
        {
            Id = addedParent.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var parent = await _repository.GetFirstAsync(x => x.Id == id);
        if (parent == null)
            throw new KeyNotFoundException("Parent not found.");
        var deletedParent = await _repository.DeleteAsync(parent);
        return new BaseResponseModel
        {
            Id = deletedParent.Id
        };
    }

    public async Task<IEnumerable<ParentResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var parents = await _repository.GetAllAsyncPerson(
        x => x.Id == id,
        include: q => q.Include(x => x.Person)
        );
        return _mapper.Map<IEnumerable<ParentResponseModel>>(parents);
    }

    public async Task<UpdateParentResponseModel> UpdateAsync(Guid id, UpdateParentModel updateParentModel, CancellationToken cancellationToken = default)
    {
        var parent = await _repository.GetFirstAsync(x => x.Id == id);
        if (parent == null)
            throw new KeyNotFoundException("Parent not found.");
        _mapper.Map(updateParentModel, parent);
        var updatedParent = await _repository.UpdateAsync(parent);
        return new UpdateParentResponseModel
        {
            Id = updatedParent.Id
        };
    }
}
