﻿namespace N_Tier.Application.Models.Exam;

public class UpdateExamModel
{
    public Guid GroupId { get; set; }
    public Guid SubjectId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime DateTime { get; set; }
}

public class UpdateExamResponseModel : BaseResponseModel { }
