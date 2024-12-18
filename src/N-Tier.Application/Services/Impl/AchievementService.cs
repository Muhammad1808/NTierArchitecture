using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Achievement;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class AchievementService : IAchievementService
{
    private readonly IAchievementRepository _repository;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public AchievementService(IMapper mapper, IAchievementRepository repository, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateAchievementResponseModel> CreateAsync(CreateAchievementModel createAchievementModel, CancellationToken cancellationToken = default)
    {
        var student = await _studentRepository.GetFirstAsync(s => s.Id == createAchievementModel.StudentId);
        var achievement = _mapper.Map<Achievement>(createAchievementModel);
        achievement.Student = student;
        var addedAchievement = await _repository.AddAsync(achievement);
        return new CreateAchievementResponseModel
        {
            Id = addedAchievement.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var achievement = await _repository.GetFirstAsync(x => x.Id == id);
        if (achievement == null)
            throw new KeyNotFoundException("Achievement not found.");
        var deletedAchievement = await _repository.DeleteAsync(achievement);
        return new BaseResponseModel
        {
            Id = deletedAchievement.Id
        };
    }

    public async Task<IEnumerable<AchievementResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var achievements = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<AchievementResponseModel>>(achievements);
    }

    public async Task<UpdateAchievementResponseModel> UpdateAsync(Guid id, UpdateAchievementModel updateAchievementModel, CancellationToken cancellationToken = default)
    {
        var achievement = await _repository.GetFirstAsync(x => x.Id == id);
        if (achievement == null)
            throw new KeyNotFoundException("Achievement not found.");
        _mapper.Map(updateAchievementModel, achievement);
        var updatedAchievement = await _repository.UpdateAsync(achievement);
        return new UpdateAchievementResponseModel
        {
            Id = updatedAchievement.Id
        };
    }
}
