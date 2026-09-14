namespace GameDirectoryService.Domain.ValueObjects;

public record HierarchyPath
{
    public string Value { get; }

    public HierarchyPath(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Path cannot be empty");

        if (value.Length > 500)
            throw new ArgumentException("Path cannot exceed 500 characters");

        if (!IsValidPath(value))
            throw new ArgumentException("Path must be in format: 'parent/child' or 'root'");

        Value = value.Trim();
    }

    private static bool IsValidPath(string path)
    {
        var segments = path.Split('/');
        return segments.All(s => !string.IsNullOrWhiteSpace(s));
    }

    public static HierarchyPath CreateRoot(Slug slug) => new(slug.Value);

    public static HierarchyPath CreateChild(HierarchyPath parent, Slug slug) => new($"{parent.Value}/{slug.Value}");

    public override string ToString() => Value;
}