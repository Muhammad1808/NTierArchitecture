using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class SchudeleRepository:BaseRepository<Schudele>, ISchudeleRepository
{
    public SchudeleRepository(DatabaseContext context):base(context)
    {
        
    }
}
