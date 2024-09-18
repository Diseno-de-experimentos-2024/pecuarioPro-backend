using System;
using System.Globalization;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;
using PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Transform;

public class CreateVaccineCommandFromResourceAssembler
{
    public static CreateVaccineCommand ToCommandFromResource(CreateVaccineResource resource)
    {
        return new CreateVaccineCommand(
            resource.Name,
            resource.Date,
            resource.Code,
            resource.Reason,
            resource.Dose,
            resource.UserId,
            resource.BovineId);
    }
}