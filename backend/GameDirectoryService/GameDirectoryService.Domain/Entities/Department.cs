using GameDirectoryService.Domain.ValueObjects;

namespace GameDirectoryService.Domain.Entities;

public class Department
{
    public int Id { get; private set; }
    public DepartmentName Name { get; private set; }
    public Slug Slug { get; private set; }
    public HierarchyPath Path { get; private set; }
    public int? ParentId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Department() { }

    public static Department Create(DepartmentName name, Slug slug, HierarchyPath path, int? parentId = null)
    {
        var department = new Department
        {
            Name = name,
            Slug = slug,
            Path = path,
            ParentId = parentId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return department;
    }

    public void UpdateName(DepartmentName newName)
    {
        Name = newName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePath(HierarchyPath newPath)
    {
        Path = newPath;
        UpdatedAt = DateTime.UtcNow;
    }
}