using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositoties
{
    /// <summary>
    /// Interface for RegionRepository
    /// </summary>
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetById(Guid id);

        Task<Region?> CreateAsync(Region region);

        Task<Region?> UpdateRegionByIdAsync(Guid Id, Region region);

        Task<Region?> DeleteRegionAsyn(Guid Id);
    }
}
