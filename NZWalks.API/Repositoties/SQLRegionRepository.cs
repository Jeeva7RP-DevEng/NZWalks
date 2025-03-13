using Microsoft.AspNetCore.Http.HttpResults;
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
        /// Get All regions Asynchronously  
        /// </summary>
        /// <returns>regions</returns>
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
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
        public async Task<Region?> DeleteRegionAsyn(Guid Id)
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
