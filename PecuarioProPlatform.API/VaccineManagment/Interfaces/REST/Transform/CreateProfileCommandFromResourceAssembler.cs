using System;
using System.Globalization;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

public class CreateProfileCommandFromResourceAssembler
{
    public static CreateVaccineCommand ToCommandFromResource(CreateVaccineResource resource)
    {
        // Assuming date is in "dd/MM/yyyy" format
        string dateString = resource.Date;
        string format = "dd/MM/yyyy";
        DateTime date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

        return new CreateVaccineCommand(
            resource.Name,
            date,
            resource.Code,
            resource.Reason);
    }
}