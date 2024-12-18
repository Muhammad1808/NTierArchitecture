﻿using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class ParentRepository:BaseRepository<Parent>, IParentRepository
{
    public ParentRepository(DatabaseContext context):base(context)
    {
        
    }
}
