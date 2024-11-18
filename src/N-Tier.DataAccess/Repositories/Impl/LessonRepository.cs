﻿using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class LessonRepository:BaseRepository<Lesson>, ILessonRepository
{
    public LessonRepository(DatabaseContext context):base(context)
    {
        
    }
}