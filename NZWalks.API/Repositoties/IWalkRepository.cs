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
        /// Retrieves all Walks asynchronously with optional filtering and sorting.
        /// </summary>
        /// <param name="filterOn">The field to filter on (e.g., "Name", "Region").</param>
        /// <param name="filterQuery">The query to filter the results by.</param>
        /// <param name="sortBy">The field to sort by (e.g., "Name", "LengthInkm").</param>
        /// <param name="isAscending">Indicates whether the sorting should be in ascending order.</param>
        /// <returns>A list of Walk objects that match the filter and sort criteria.</returns>
        Task<List<Walk>> GetAllAsync(string? filterOn, string? filterQuery, string? sortBy, bool isAscending);

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

