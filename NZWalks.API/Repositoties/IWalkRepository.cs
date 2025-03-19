using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositoties
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
    }
}
