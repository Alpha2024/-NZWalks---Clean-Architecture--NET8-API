using NZwalks.Core.Domain.Entities;

namespace NZWalks.API.ServiceContracts
{
    public interface IServiceContract
    {
        Task<List<Region>> GetAllRegions();
        Task<Region> AddRegion(Region region);
        Task<Region?> GetRegionById(Guid regionId);
        Task<Region> UpdateRegion(Region region);
        Task<bool> DeleteRegion(Guid regionId);
        Task<Walk> CreateWalkAsync(Walk walk);
        Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterBy = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pagesize = 1000);
        Task<Walk?> GetWalk(Guid id);
        Task<Walk> UpdateWalks(Guid walkid, Walk walk);
        Task<bool> DeleteWalksAsync(Guid id);
    }
}
