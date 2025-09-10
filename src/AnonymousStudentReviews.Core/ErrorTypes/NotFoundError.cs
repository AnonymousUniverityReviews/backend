using AnonymousStudentReviews.Core.Abstractions;

namespace AnonymousStudentReviews.Core.ErrorTypes;

public record NotFoundError(string Title, string Details) : Error(Title, Details)
{
}
