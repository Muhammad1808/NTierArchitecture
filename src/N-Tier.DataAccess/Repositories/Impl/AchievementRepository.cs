using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class AchievementRepository:BaseRepository<Achievement>, IAchievementRepository
{
    public AchievementRepository(DatabaseContext context):base(context)
    {
        
    }
}
