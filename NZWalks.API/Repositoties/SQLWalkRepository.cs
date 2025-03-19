using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

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
                
            }
            return walk;
        }
    }
}
