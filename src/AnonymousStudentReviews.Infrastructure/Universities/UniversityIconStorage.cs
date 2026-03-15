using AnonymousStudentReviews.Core.Abstractions;

using Microsoft.AspNetCore.Hosting;

namespace AnonymousStudentReviews.Infrastructure.Universities;

public class UniversityIconStorage : IUniversityIconStorage
{
    private readonly IWebHostEnvironment _environment;

    public UniversityIconStorage(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> SaveAsync(
        Stream fileStream,
        string fileName,
        CancellationToken cancellationToken = default)
    {
        var ext = Path.GetExtension(fileName).ToLowerInvariant();

        var webRoot = _environment.WebRootPath;
        if (string.IsNullOrWhiteSpace(webRoot))
        {
            webRoot = Path.Combine(AppContext.BaseDirectory, "wwwroot");
        }

        var dir = Path.Combine(webRoot, "uploads", "universities");
        Directory.CreateDirectory(dir);

        var storedFileName = $"{Guid.NewGuid():N}{ext}";
        var fullPath = Path.Combine(dir, storedFileName);

        await using var output = System.IO.File.Create(fullPath);
        await fileStream.CopyToAsync(output, cancellationToken);

        return $"/uploads/universities/{storedFileName}";
    }
}
