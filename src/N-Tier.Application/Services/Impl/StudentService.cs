using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Student;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IMapper _mapper;
    private readonly IParentRepository _parentRepository;
    private readonly IGroupRepository _groupRepository;

    public StudentService(IMapper mapper, IStudentRepository repository, IParentRepository parentRepository, IGroupRepository groupRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _parentRepository = parentRepository;
        _groupRepository = groupRepository;
    }

    public async Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel, CancellationToken cancellationToken = default)
    {
        var parent=await _parentRepository.GetFirstAsync(p=>p.Id==createStudentModel.ParentId);
        var group=await _groupRepository.GetFirstAsync(g=>g.Id==createStudentModel.GroupId);
        var student = _mapper.Map<Student>(createStudentModel);
        student.Parent = parent;
        student.Group = group;
        var addedStudent = await _repository.AddAsync(student);
        return new CreateStudentResponseModel
        {
            Id = addedStudent.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var student = await _repository.GetFirstAsync(x => x.Id == id);
        if (student == null)
            throw new KeyNotFoundException("Student not found.");
        var deletedStudent = await _repository.DeleteAsync(student);
        return new BaseResponseModel
        {
            Id = deletedStudent.Id
        };
    }

    public async Task<IEnumerable<StudentResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var students = await _repository.GetAllAsyncPerson(
        x => x.Id == id,
        include: q => q.Include(x => x.Person)
        );

        return _mapper.Map<IEnumerable<StudentResponseModel>>(students);
    }

    public async Task<UpdateStudentResponseModel> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel, CancellationToken cancellationToken = default)
    {
        var student = await _repository.GetFirstAsync(x => x.Id == id);
        if (student == null)
            throw new KeyNotFoundException("Student not found.");
        _mapper.Map(updateStudentModel, student);
        var updatedStudent = await _repository.UpdateAsync(student);
        return new UpdateStudentResponseModel
        {
            Id = updatedStudent.Id
        };
    }
}
