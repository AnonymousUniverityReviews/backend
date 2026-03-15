namespace AnonymousStudentReviews.Core.Abstractions;

public interface IUniversityIconStorage
{
    Task<string> SaveAsync(Stream fileStream, string fileName, CancellationToken cancellationToken = default);
}
