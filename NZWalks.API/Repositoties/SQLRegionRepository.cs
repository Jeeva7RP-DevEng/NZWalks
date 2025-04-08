using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositoties
{
    /// <summary>
    /// SQLRegionRepository Class to store Database
    /// </summary>
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;
        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        /// <summary>
        /// Retrieves all regions asynchronously with optional filtering and sorting.
        /// </summary>
        /// <param name="filterOn">The field to filter on.</param>
        /// <param name="filterQuery">The query to filter the field with.</param>
        /// <param name="sortBy">The field to sort by.</param>
        /// <param name="isAscending">Indicates whether the sorting should be in ascending order.</param>
        /// <returns>A list of regions that match the filter and sorting criteria.</returns>
        public async Task<List<Region>> GetAllAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            string? sortBy, bool isAscending = false, [FromQuery] int? pageNumber = 0, [FromQuery] int? pageSize = 0)
        {
            var regions = dbContext.Regions.AsQueryable();
            //Filtering

            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                switch (filterOn.ToLower())
                {
                    case "name":
                        regions = regions.Where(r => r.Name.Contains(filterQuery));
                        break;

                    case "code":
                        regions = regions.Where(r => r.Code.Contains(filterQuery));
                        break;

                        // Add more filters easily here
                }
            }

            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        regions = isAscending ? regions.OrderBy(x => x.Name) : regions.OrderByDescending(x => x.Name);
                        break;
                    case "code":
                        regions = isAscending ? regions.OrderBy(x => x.Code) : regions.OrderByDescending(x => x.Code);
                        break;

                }
            }

            // Pagination
            if (pageNumber.HasValue && pageSize.HasValue && pageNumber > 0 && pageSize > 0)
            {
                var skipResult = (pageNumber.Value - 1) * pageSize.Value;
                regions = regions.Skip(skipResult).Take(pageSize.Value);
            }

            return await regions.ToListAsync();
        }


        /// <summary>
        /// Get region By Id Asynchronously  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>region</returns>
        public async Task<Region?> GetById(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            //return region != null ? new List<Region?> { region } : new List<Region?>();

        }
        /// <summary>
        /// Create regions Asynchronously  
        /// </summary>
        /// <param name="region"></param>
        /// <returns>regions</returns>
        public async Task<Region?> CreateAsync(Region region)
        {
            if (region == null)
            {
                return null;
            }

            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
        /// <summary>
        /// Update regions By Id Asynchronously  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="region"></param>
        /// <returns>regions</returns>
        public async Task<Region?> UpdateRegionByIdAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        /// <summary>
        /// Delete  region By Id Asynchronously  
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Deleted regions</returns>
        public async Task<Region?> DeleteRegionAsync(Guid Id)
        {
            var regionDeleted = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == Id);
            if (regionDeleted == null)
            {
                return null;
            }

            dbContext.Regions.Remove(regionDeleted);
            await dbContext.SaveChangesAsync();
            return regionDeleted;
        }
    }
}
