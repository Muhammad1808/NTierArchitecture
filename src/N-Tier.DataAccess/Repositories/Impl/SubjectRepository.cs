using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class SubjectRepository:BaseRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(DatabaseContext context):base(context)
    {
        
    }
}
