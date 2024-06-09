using PecuarioProPlatform.API.VaccineManagment.Domain.Model.aggregates;
using PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;

namespace PecuarioProPlatform.API.VaccineManagment.Domain.Services;

public interface IVaccineCommandService
{
    Task<Vaccines?> Handle(CreateVaccineCommand command);
    /*Task<Vaccines?> Handle(UpdateVaccineCommand command);
    Task<Vaccines?> Handle(DeleteVaccineCommand command);*/
}