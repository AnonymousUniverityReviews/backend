using AnonymousStudentReviews.Core.Abstractions;
using AnonymousStudentReviews.Core.Aggregates.University;

namespace AnonymousStudentReviews.UseCases.Universities.Update;

public class UpdateUniversityService : IUpdateUniversityService
{
    private readonly IUniversityRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUniversityService(IUniversityRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<University>> ExecuteAsync(UpdateUniversityDto dto)
    {
        var getResult = await _repository.FindByIdAsync(dto.UniversityId);

        if (getResult.IsFailure)
        {
            return Result.Failure<University>(getResult.Error);
        }

        var university = getResult.Value;

        university.Name = dto.Name;
        university.City = dto.City;
        university.Website = dto.Website;
        university.Description = dto.Description;

        var updateResult = await _repository.UpdateAsync(university);

        if (updateResult.IsFailure)
        {
            return updateResult;
        }

        await _unitOfWork.SaveChangesAsync();

        return updateResult;
    }
}
