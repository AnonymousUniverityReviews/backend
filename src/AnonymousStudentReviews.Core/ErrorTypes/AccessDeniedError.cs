using AnonymousStudentReviews.Core.Abstractions;

namespace AnonymousStudentReviews.Core.ErrorTypes;

public record AccessDeniedError(string Title, string Details) : Error(Title, Details)
{
}
