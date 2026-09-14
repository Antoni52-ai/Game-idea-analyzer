using GameDirectoryService.Domain.ValueObjects;

namespace GameDirectoryService.Domain.Entities;

public class Location
{
    public int Id { get; private set; }
    public DepartmentName Name { get; private set; }
    public Address Address { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Location() { } // Для EF Core

    public static Location Create(DepartmentName name, Address address)
    {
        var location = new Location
        {
            Name = name,
            Address = address,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return location;
    }

    public void UpdateName(DepartmentName newName)
    {
        Name = newName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateAddress(Address newAddress)
    {
        Address = newAddress;
        UpdatedAt = DateTime.UtcNow;
    }
}