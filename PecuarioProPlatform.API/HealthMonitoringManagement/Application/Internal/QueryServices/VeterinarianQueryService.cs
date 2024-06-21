using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Queries;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Repositories;
using PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Services;

namespace PecuarioProPlatform.API.HealthMonitoringManagement.Application.Internal.QueryServices;

public class VeterinarianQueryService(IVeterinarianRepository veterinarianRepository) : IVeterinarianQueryService
{
    public async Task<Veterinarians?> Handle(GetVeterinariansBySpecialty query)
    {
        return await veterinarianRepository.FindBySpecialty(query.Specialty);
    }

    public async Task<IEnumerable<Veterinarians>> Handle(GetAllVeterinariansQuery query)
    {
        return await veterinarianRepository.ListAsync();
    }

    public async Task<Veterinarians?> Handle(GetVeterinariansByIdQuery query)
    {
        return await veterinarianRepository.FindByIdAsync(query.IdVeterinarian);
    }

    public async Task<Veterinarians?> Handle(GetVeterinariansByEmailQuery query)
    {
        return await veterinarianRepository.FindByEmail(query.Email);
    }
}