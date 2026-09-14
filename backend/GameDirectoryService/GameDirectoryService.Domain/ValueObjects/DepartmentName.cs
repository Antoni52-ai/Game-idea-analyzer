namespace GameDirectoryService.Domain.ValueObjects;

public record DepartmentName
{
    public string Value { get; }

    public DepartmentName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Department name cannot be empty");

        if (value.Length > 255)
            throw new ArgumentException("Department name cannot exceed 255 characters");

        Value = value.Trim();
    }

    public override string ToString() => Value;
}