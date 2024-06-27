using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Services;

public interface IVaccineCommandService
{
    Task<Vaccine?> Handle(CreateVaccineCommand command);
    Task<Vaccine?> Handle(UpdateVaccineCommand command);
    Task<Vaccine?> Handle(DeleteVaccineCommand command);
    
}