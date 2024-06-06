using PecuarioProPlatform.API.Shared.Domain.Model.Entities;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

public class Origin
{
    public int Id { get; private set; }
    public int DistrictId { get; private set; }
    public District District { get; private set; }
    public int CityId { get; private set; }
    public City City { get; private set; }
    public int DepartmentId { get; private set; }
    public Department Department { get; private set; }

    private Origin() { }

    public Origin(int districtId, int cityId, int departmentId)
    {
        DistrictId = districtId;
        CityId = cityId;
        DepartmentId = departmentId;
    }

    public Origin(int districtId,District district, int cityId,City city, int departmentId,Department department)
    {
        DistrictId = districtId;
        CityId = cityId;
        DepartmentId = departmentId;
        Department = department;
        District = district;
        City = city;
    }
}