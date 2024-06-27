using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

public class UpdateVaccineCommandFromResourceAssembler
{
    public static UpdateVaccineCommand ToCommandFromResource(int vaccineId, CreateVaccineResource resource)
    {
        DateTime date;
        if (!DateTime.TryParse(resource.Date, out date))
        {
            throw new FormatException("Invalid date format");
        }

        return new UpdateVaccineCommand(vaccineId, resource.Name, date, resource.Code, resource.Reason);
    }
}