namespace GameDirectoryService.Domain.Entities;

public class DepartmentPosition
{
    public int Id { get; private set; }
    public int DepartmentId { get; private set; }
    public int PositionId { get; private set; }

    private DepartmentPosition() { } // Для EF Core

    public static DepartmentPosition Create(int departmentId, int positionId)
    {
        if (departmentId <= 0)
            throw new ArgumentException("DepartmentId must be positive");

        if (positionId <= 0)
            throw new ArgumentException("PositionId must be positive");

        var departmentPosition = new DepartmentPosition
        {
            DepartmentId = departmentId,
            PositionId = positionId
        };

        return departmentPosition;
    }
}