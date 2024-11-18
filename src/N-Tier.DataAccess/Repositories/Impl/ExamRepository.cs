using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class ExamRepository:BaseRepository<Exam>, IExamRepository
{
    public ExamRepository(DatabaseContext context):base(context)
    {
        
    }
}
