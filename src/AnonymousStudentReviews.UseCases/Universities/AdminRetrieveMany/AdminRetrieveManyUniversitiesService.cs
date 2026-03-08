using AnonymousStudentReviews.Core.Abstractions;
using AnonymousStudentReviews.Core.Aggregates.University;

namespace AnonymousStudentReviews.UseCases.Universities.AdminRetrieveMany;

public class AdminRetrieveManyUniversitiesService : IAdminRetrieveManyUniversitiesService
{
    private readonly IUniversityRepository _universityRepository;

    public AdminRetrieveManyUniversitiesService(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }

    public async Task<Result<OffsetPagedResult<UniversityPreview>>> HandleAsync(AdminRetrieveManyUniversitiesDto dto)
    {
        var result = await _universityRepository.GetAllOffsetAsync(
            dto.Query,
            dto.Name,
            dto.City,
            dto.UniversitySortBy,
            dto.SortOrder,
            dto.Offset,
            dto.Limit);

        return Result.Success(result);
    }
}
