namespace GameDirectoryService.Domain.Entities;

public class DepartmentLocation
{
    public int Id { get; private set; }
    public int DepartmentId { get; private set; }
    public int LocationId { get; private set; }
    public bool IsPrimary { get; private set; }

    private DepartmentLocation() { } // Для EF Core

    public static DepartmentLocation Create(int departmentId, int locationId, bool isPrimary = false)
    {
        if (departmentId <= 0)
            throw new ArgumentException("DepartmentId must be positive");

        if (locationId <= 0)
            throw new ArgumentException("LocationId must be positive");

        var departmentLocation = new DepartmentLocation
        {
            DepartmentId = departmentId,
            LocationId = locationId,
            IsPrimary = isPrimary
        };

        return departmentLocation;
    }

    public void SetAsPrimary(bool isPrimary)
    {
        IsPrimary = isPrimary;
    }
}