using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class CourseRepository:BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(DatabaseContext context):base(context)
    {
        
    }
}
