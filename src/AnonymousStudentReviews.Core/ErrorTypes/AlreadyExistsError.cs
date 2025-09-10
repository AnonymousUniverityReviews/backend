using AnonymousStudentReviews.Core.Abstractions;

namespace AnonymousStudentReviews.Core.ErrorTypes;

public record AlreadyExistsError(string Title, string Details) : Error(Title, Details)
{
}
