using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class RoomRepository:BaseRepository<Room>,IRoomRepository
{
    public RoomRepository(DatabaseContext context):base(context)
    {
        
    }
}
