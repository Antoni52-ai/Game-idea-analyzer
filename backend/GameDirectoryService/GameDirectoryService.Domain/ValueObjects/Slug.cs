using System.Text.RegularExpressions;

namespace GameDirectoryService.Domain.ValueObjects;

public record Slug
{
    private static readonly Regex SlugRegex = new(@"^[a-z0-9]+(?:-[a-z0-9]+)*$", RegexOptions.Compiled);

    public string Value { get; }

    public Slug(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Slug cannot be empty");

        if (!SlugRegex.IsMatch(value))
            throw new ArgumentException("Slug must contain only lowercase letters, numbers, and hyphens");

        if (value.Length > 100)
            throw new ArgumentException("Slug cannot exceed 100 characters");

        Value = value.ToLower().Trim();
    }

    public override string ToString() => Value;
}