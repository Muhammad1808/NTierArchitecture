using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Transport;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class TransportService : ITransportService
{
    private readonly ITransportRepository _repository;
    private readonly IMapper _mapper;

    public TransportService(IMapper mapper, ITransportRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateTransportResponseModel> CreateAsync(CreateTransportModel createTransportModel, CancellationToken cancellationToken = default)
    {
        var transport = _mapper.Map<Transport>(createTransportModel);
        var addedTransport = await _repository.AddAsync(transport);
        return new CreateTransportResponseModel
        {
            Id = addedTransport.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var transport = await _repository.GetFirstAsync(x => x.Id == id);
        if (transport == null)
            throw new KeyNotFoundException("Transport not found.");
        var deletedTransport = await _repository.DeleteAsync(transport);
        return new BaseResponseModel
        {
            Id = deletedTransport.Id
        };
    }

    public async Task<IEnumerable<TransportResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var transports = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<TransportResponseModel>>(transports);
    }

    public async Task<UpdateTransportResponseModel> UpdateAsync(Guid id, UpdateTransportModel updateTransportModel, CancellationToken cancellationToken = default)
    {
        var transport = await _repository.GetFirstAsync(x => x.Id == id);
        if (transport == null)
            throw new KeyNotFoundException("Transport not found.");
        _mapper.Map(updateTransportModel, transport);
        var updatedTransport = await _repository.UpdateAsync(transport);
        return new UpdateTransportResponseModel
        {
            Id = updatedTransport.Id
        };
    }
}
