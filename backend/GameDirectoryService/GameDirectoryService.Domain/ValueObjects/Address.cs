namespace GameDirectoryService.Domain.ValueObjects;

public record Address
{
    public string Value { get; }

    public Address(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Address cannot be empty");

        if (value.Length > 500)
            throw new ArgumentException("Address cannot exceed 500 characters");

        Value = value.Trim();
    }

    public override string ToString() => Value;
}