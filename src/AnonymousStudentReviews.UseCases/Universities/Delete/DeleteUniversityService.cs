using AnonymousStudentReviews.Core.Abstractions;
using AnonymousStudentReviews.Core.Aggregates.University;

namespace AnonymousStudentReviews.UseCases.Universities.Delete;

public class DeleteUniversityService : IDeleteUniversityService
{
    private readonly IUniversityRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUniversityService(IUniversityRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> ExecuteAsync(Guid universityId)
    {
        var result = await _repository.DeleteAsync(universityId);

        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
