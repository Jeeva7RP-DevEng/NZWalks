using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositoties
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            try
            {
                await dbContext.AddAsync(walk);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return walk;
        }


        ///</summary>
        /// Retrieves all Walks asynchronously with optional filtering and sorting.
        /// </summary>
        /// <param name="filterOn">The field to filter on (e.g., "name", "code").</param>
        /// <param name="filterQuery">The query string to filter the results.</param>
        /// <param name="sortBy">The field to sort by (e.g., "name", "lengthinkm").</param>
        /// <param name="isAscending">Specifies whether the sorting should be in ascending order.</param>
        /// <returns>A list of Walk objects that match the filtering and sorting criteria.</returns>
        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = false)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                switch (filterOn.ToLower())
                {
                    case "name":
                        walks = walks.Where(r => r.Name.Contains(filterQuery));
                        break;

                    case "code":
                        walks = walks.Where(r => r.Description.Contains(filterQuery));
                        break;

                        // Add more filters easily here
                }
            }

            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                        break;
                    case "lengthinkm":
                        walks = isAscending ? walks.OrderBy(x => x.LengthInkm) : walks.OrderByDescending(x => x.LengthInkm);
                        break;

                }
            }

            return await walks.ToListAsync();
        }

        /// <summary>
        /// Get Walks By Id as Async
        /// </summary>
        /// <returns></returns>
        public async Task<Walk?> GetWalksByIdAsync(Guid id)
        {
            var walkDomainModel = await dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);

            return walkDomainModel;
        }

        /// <summary>
        /// Update walks asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <param name="walk"></param>
        /// <returns></returns>
        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            // Validate DifficultyId exists
            var difficultyExists = await dbContext.Difficulties.AnyAsync(d => d.Id == walk.DifficultyId);
            if (!difficultyExists)
                return null;

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInkm = walk.LengthInkm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();

            return existingWalk;
        }

        /// <summary>
        /// Deletes a Walk by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the Walk to delete.</param>
        /// <returns>The deleted Walk object if the deletion was successful; otherwise, null.</returns>
        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existwalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existwalk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(existwalk);
            await dbContext.SaveChangesAsync();
            return existwalk;
        }
    }
}
