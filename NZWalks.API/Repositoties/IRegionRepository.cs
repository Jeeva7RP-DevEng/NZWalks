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
        /// <summary>
        /// Retrieves all regions asynchronously.
        /// </summary>
        /// <returns>A list of regions.</returns>
        Task<List<Region>> GetAllAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery);

        /// <summary>
        /// Retrieves a region by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the region.</param>
        /// <returns>The region if found; otherwise, null.</returns>
        Task<Region?> GetById(Guid id);

        /// <summary>
        /// Creates a new region asynchronously.
        /// </summary>
        /// <param name="region">The region to create.</param>
        /// <returns>The created region.</returns>
        Task<Region?> CreateAsync(Region region);

        /// <summary>
        /// Updates an existing region by its unique identifier asynchronously.
        /// </summary>
        /// <param name="Id">The unique identifier of the region to update.</param>
        /// <param name="region">The updated region details.</param>
        /// <returns>The updated region if successful; otherwise, null.</returns>
        Task<Region?> UpdateRegionByIdAsync(Guid Id, Region region);

        /// <summary>
        /// Deletes a region by its unique identifier asynchronously.
        /// </summary>
        /// <param name="Id">The unique identifier of the region to delete.</param>
        /// <returns>The deleted region if successful; otherwise, null.</returns>
        Task<Region?> DeleteRegionAsyn(Guid Id);
    }
}
