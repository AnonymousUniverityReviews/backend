namespace AnonymousStudentReviews.Core.Abstractions;

public record Error(string Title, string Details)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");

    public string Title { get; } = Title;
    public string Details { get; } = Details;
}
