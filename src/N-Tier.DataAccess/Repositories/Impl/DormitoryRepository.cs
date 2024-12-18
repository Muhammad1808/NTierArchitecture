using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class DormitoryRepository:BaseRepository<Dormitory>,IDormitoryRepository
{
    public DormitoryRepository(DatabaseContext context):base(context)
    {
        
    }
}
