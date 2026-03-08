using AnonymousStudentReviews.Core.Abstractions;
using AnonymousStudentReviews.Core.Aggregates.University;

namespace AnonymousStudentReviews.UseCases.Universities.AdminRetrieveMany;

public interface IAdminRetrieveManyUniversitiesService
{
    Task<Result<OffsetPagedResult<UniversityPreview>>> HandleAsync(AdminRetrieveManyUniversitiesDto dto);
}
