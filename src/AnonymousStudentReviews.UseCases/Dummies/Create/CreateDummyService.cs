using AnonymousStudentReviews.Core.Abstractions;
using AnonymousStudentReviews.Core.DummyAggregate;

namespace AnonymousStudentReviews.UseCases.Dummies.Create;

public class CreateDummyService : ICreateDummyService
{
    private readonly IDummyRepository _dummyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDummyService(IDummyRepository dummyRepository, IUnitOfWork unitOfWork)
    {
        _dummyRepository = dummyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Dummy>> ExecuteAsync(CreateDummyDto dto)
    {
        var badCondition = false;
        if (badCondition)
        {
            return Result.Failure<Dummy>(CreateDummyErrors.SomeError);
        }

        var dummy = Dummy.Create("").Value;

        _dummyRepository.Create(dummy);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(dummy);
    }
}
