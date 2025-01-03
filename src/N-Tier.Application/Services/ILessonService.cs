﻿using N_Tier.Application.Models;
using N_Tier.Application.Models.Lesson;

namespace N_Tier.Application.Services;

public interface ILessonService
{
    Task<CreateLessonResponseModel> CreateAsync(CreateLessonModel createLessonModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<LessonResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateLessonResponseModel> UpdateAsync(Guid id, UpdateLessonModel updateLessonModel,
        CancellationToken cancellationToken = default);
}
