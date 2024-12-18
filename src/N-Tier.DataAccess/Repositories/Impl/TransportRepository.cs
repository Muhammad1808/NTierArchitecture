using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class TransportRepository:BaseRepository<Transport>, ITransportRepository
{
    public TransportRepository(DatabaseContext context):base(context)
    {
        
    }
}
