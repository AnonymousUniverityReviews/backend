using AnonymousStudentReviews.Core.Abstractions;
using AnonymousStudentReviews.Core.DummyAggregate;

namespace AnonymousStudentReviews.UseCases.Dummies.Create;

public interface ICreateDummyService
{
    Task<Result<Dummy>> ExecuteAsync(CreateDummyDto dto);
}
