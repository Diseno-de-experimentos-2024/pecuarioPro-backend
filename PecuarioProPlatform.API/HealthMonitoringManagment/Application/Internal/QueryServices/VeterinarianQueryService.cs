using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Entities;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Queries;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Repositories;
using PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Services;

namespace PecuarioProPlatform.API.HealthMonitoringManagment.Application.Internal.QueryServices;

public class VeterinarianQueryService(IVeterinarianRepository veterinarianRepository) : IVeterinarianQueryService
{
    public async Task<Veterinarians> Handle(GetVeterinariansBySpecialty query)
    {
        return await veterinarianRepository.FindBySpecialty(query.Specialty);
    }

    public async Task<IEnumerable<Veterinarians>> Handle(GetAllVeterinariansQuery query)
    {
        return await veterinarianRepository.ListAsync();
    }

    public async Task<Veterinarians> Handle(GetVeterinariansByIdQuery query)
    {
        return await veterinarianRepository.FindByIdAsync(query.IdVeterinarian);
    }
}