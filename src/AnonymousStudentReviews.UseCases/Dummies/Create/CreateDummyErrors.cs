using AnonymousStudentReviews.Core.Abstractions;
using AnonymousStudentReviews.Core.ErrorTypes;

namespace AnonymousStudentReviews.UseCases.Dummies.Create;

public static class CreateDummyErrors
{
    public static readonly AccessDeniedError SomeError1 = new("Access denied", "some error");
    public static readonly Error SomeBadRequestError = new("Invalid data", "some error");
}
