using AnonymousStudentReviews.Core.Abstractions;
using AnonymousStudentReviews.Core.Aggregates.University;

namespace AnonymousStudentReviews.UseCases.Universities.Create;

public class CreateUniversityService : ICreateUniversityService
{
    private readonly IUniversityRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUniversityService(IUniversityRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<University>> ExecuteAsync(CreateUniversityDto dto)
    {
        var university = new University
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            City = dto.City,
            Website = dto.Website,
            IconUrl = dto.IconUrl,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(university);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(university);
    }
}
