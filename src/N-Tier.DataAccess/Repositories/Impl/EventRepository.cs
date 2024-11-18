using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class EventRepository:BaseRepository<Event>, IEventRepository
{
    public EventRepository(DatabaseContext context):base(context)
    {
        
    }
}
