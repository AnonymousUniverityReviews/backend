namespace AnonymousStudentReviews.UseCases.Universities.UploadIcon;

public class UploadUniversityIconDto
{
    public required Stream FileStream { get; init; }
    public required string FileName { get; init; }
}
