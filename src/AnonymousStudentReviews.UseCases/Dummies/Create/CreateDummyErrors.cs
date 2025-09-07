using AnonymousStudentReviews.Core.Abstractions;

namespace AnonymousStudentReviews.UseCases.Dummies.Create;

public static class CreateDummyErrors
{
    public static readonly Error SomeError = new("Dummies.Create.SomeError", "some error");
}
