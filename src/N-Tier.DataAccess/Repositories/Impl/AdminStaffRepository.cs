using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class AdminStaffRepository:BaseRepository<AdminStaff>, IAdminStaffRepository
{
    public AdminStaffRepository(DatabaseContext context):base(context)
    {
        
    }
}
