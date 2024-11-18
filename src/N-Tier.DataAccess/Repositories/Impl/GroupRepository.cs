using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class GroupRepository:BaseRepository<Group>, IGroupRepository
{
    public GroupRepository(DatabaseContext context):base(context)
    {
        
    }
}
