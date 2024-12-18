using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using N_Tier.Application.Common.Email;
using N_Tier.Application.MappingProfiles;
using N_Tier.Application.Services;
using N_Tier.Application.Services.DevImpl;
using N_Tier.Application.Services.Impl;
using N_Tier.Shared.Services;
using N_Tier.Shared.Services.Impl;

namespace N_Tier.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        services.RegisterCashing();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        services.AddScoped<ITodoListService, TodoListService>();
        services.AddScoped<ITodoItemService, TodoItemService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<ITemplateService, TemplateService>();
        services.AddScoped<IAboutSchoolService, AboutSchoolService>();
        services.AddScoped<IAchievementService, AchievementService>();
        services.AddScoped<IAdminStaffService, AdminStaffService>();
        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IDiaryService, DiaryService>();
        services.AddScoped<IDormitoryService,DormitoryService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IExamService, ExamService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IParentService, ParentService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<ISchudeleService, ScheduleService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ISubjectService,SubjectService>();
        services.AddScoped<ITransportService, TransportService>();

        if (env.IsDevelopment())
            services.AddScoped<IEmailService, DevEmailService>();
        else
            services.AddScoped<IEmailService, EmailService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    private static void RegisterCashing(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }

    public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
    }
}
