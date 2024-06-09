namespace PecuarioProPlatform.API.Shared.Domain.Model.Entities;

public class City
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int DepartmentId { get; private set; }
    public Department Department { get;  set; }

    private City() { } 

    public City(string name, int departmentId)
    {
        Name = name;
        DepartmentId = departmentId;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}