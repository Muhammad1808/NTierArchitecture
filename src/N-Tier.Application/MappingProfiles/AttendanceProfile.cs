﻿using AutoMapper;
using N_Tier.Application.Models.Attendance;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class AttendanceProfile:Profile
{
    public AttendanceProfile()
    {
        CreateMap<CreateAttendanceModel, Attendance>();
        CreateMap<UpdateAttendanceModel, Attendance>();
        CreateMap<Attendance,AttendanceResponseModel>();
    }
}
