using GameDirectoryService.Domain.ValueObjects;

namespace GameDirectoryService.Domain.Entities;

public class Position
{
    public int Id { get; private set; }
    public DepartmentName Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Position() { } // Для EF Core

    public static Position Create(DepartmentName name)
    {
        var position = new Position
        {
            Name = name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return position;
    }

    public void UpdateName(DepartmentName newName)
    {
        Name = newName;
        UpdatedAt = DateTime.UtcNow;
    }
}