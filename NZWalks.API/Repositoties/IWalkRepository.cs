using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositoties
{
    /// <summary>
    /// Interface for Walk repository to handle CRUD operations for Walks.
    /// </summary>
    public interface IWalkRepository
    {
        /// <summary>
        /// Creates a new Walk asynchronously.
        /// </summary>
        /// <param name="walk">The Walk object to create.</param>
        /// <returns>The created Walk object.</returns>
        Task<Walk> CreateAsync(Walk walk);

        /// <summary>
        /// Retrieves all Walks asynchronously.
        /// </summary>
        /// <returns>A list of Walk objects.</returns>
        Task<List<Walk>> GetAllAsync(string? filterOn,  string? filterQuery);

        /// <summary>
        /// Retrieves a Walk by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the Walk to retrieve.</param>
        /// <returns>The Walk object if found; otherwise, null.</returns>
        Task<Walk?> GetWalksByIdAsync(Guid id);

        /// <summary>
        /// Updates an existing Walk asynchronously.
        /// </summary>
        /// <param name="id">The ID of the Walk to update.</param>
        /// <param name="walk">The updated Walk object.</param>
        /// <returns>The updated Walk object if the update was successful; otherwise, null.</returns>
        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);

        /// <summary>
        /// Deletes a Walk by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the Walk to delete.</param>
        /// <returns>The deleted Walk object if the deletion was successful; otherwise, null.</returns>
        Task<Walk?> DeleteAsync(Guid id);
    }
}

