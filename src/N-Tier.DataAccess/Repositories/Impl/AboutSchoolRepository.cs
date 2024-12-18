using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class AboutSchoolRepository : BaseRepository<AboutSchool>, IAboutSchoolRepository
{
    public AboutSchoolRepository(DatabaseContext context) : base(context)
    {

    }
}
