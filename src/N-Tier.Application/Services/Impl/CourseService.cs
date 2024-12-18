using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Course;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;
    private readonly IMapper _mapper;
    private readonly IAboutSchoolRepository _aboutSchoolRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public CourseService(IMapper mapper, ICourseRepository repository, IAboutSchoolRepository aboutSchoolRepository, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _aboutSchoolRepository = aboutSchoolRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<CreateCourseResponseModel> CreateAsync(CreateCourseModel createCourseModel, CancellationToken cancellationToken = default)
    {
        var school = await _aboutSchoolRepository.GetFirstAsync(s => s.Id == createCourseModel.AboutSchoolId);
        var employee = await _employeeRepository.GetFirstAsync(e => e.Id == createCourseModel.EmployeeId);
        var course = _mapper.Map<Course>(createCourseModel);
        course.AboutSchool = school;
        course.Employee = employee;
        var addedCourse = await _repository.AddAsync(course);
        return new CreateCourseResponseModel
        {
            Id = addedCourse.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var course = await _repository.GetFirstAsync(x => x.Id == id);
        if (course == null)
            throw new KeyNotFoundException("Course not found.");
        var deletedCourse = await _repository.DeleteAsync(course);
        return new BaseResponseModel
        {
            Id = deletedCourse.Id
        };
    }

    public async Task<IEnumerable<CourseResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var courses = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<CourseResponseModel>>(courses);
    }

    public async Task<UpdateCourseResponseModel> UpdateAsync(Guid id, UpdateCourseModel updateCourseModel, CancellationToken cancellationToken = default)
    {
        var course = await _repository.GetFirstAsync(x => x.Id == id);
        if (course == null)
            throw new KeyNotFoundException("Course not found.");
        _mapper.Map(updateCourseModel, course);
        var updatedCourse = await _repository.UpdateAsync(course);
        return new UpdateCourseResponseModel
        {
            Id = updatedCourse.Id
        };
    }
}
