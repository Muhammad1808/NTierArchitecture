using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class DepartmentRepository:BaseRepository<Department>,IDepartmentRepository
{
    public DepartmentRepository(DatabaseContext context):base(context)
    {
        
    }
}
