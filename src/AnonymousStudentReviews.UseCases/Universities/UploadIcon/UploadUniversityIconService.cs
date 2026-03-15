using AnonymousStudentReviews.Core.Abstractions;

namespace AnonymousStudentReviews.UseCases.Universities.UploadIcon;

public class UploadUniversityIconService : IUploadUniversityIconService
{
    private static readonly string[] AllowedExtensions = [".png", ".jpg", ".jpeg", ".webp"];

    private readonly IUniversityIconStorage _iconStorage;

    public UploadUniversityIconService(IUniversityIconStorage iconStorage)
    {
        _iconStorage = iconStorage;
    }

    public async Task<Result<string>> ExecuteAsync(UploadUniversityIconDto dto)
    {
        var ext = Path.GetExtension(dto.FileName).ToLowerInvariant();

        if (!AllowedExtensions.Contains(ext))
        {
            return Result.Failure<string>(new Error(
                "UniversityIcon.UnsupportedFileType",
                "Unsupported file type. Allowed: png, jpg, jpeg, webp"));
        }

        var iconUrl = await _iconStorage.SaveAsync(dto.FileStream, dto.FileName);

        return Result.Success(iconUrl);
    }
}
