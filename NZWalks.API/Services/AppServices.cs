using NZwalks.Core.Domain.Entities;
using NZwalks.Core.Domain.RepositorieInterface;
using NZWalks.API.ServiceContracts;

namespace NZWalks.API.Services
{
    public class AppServices : IServiceContract
    {
        private readonly IRegionRepository _reposiotry;
        private readonly IWalksRepository _walks;

        public AppServices(IRegionRepository reposiotry, IWalksRepository walks)
        {
            _reposiotry = reposiotry;
            _walks = walks;
        }
        public async Task<Region> AddRegion(Region region)
        {
            return await _reposiotry.AddRegion(region);
        }

        public async Task<bool> DeleteRegion(Guid regionId)
        {
            return await _reposiotry.DeleteRegion(regionId);
        }

        public async Task<List<Region>> GetAllRegions()
        {
            return await _reposiotry.GetAllRegions();
        }

        public async Task<Region?> GetRegionById(Guid regionId)
        {
            return await _reposiotry.GetRegionById(regionId);
        }

        public async Task<Region> UpdateRegion(Region region)
        {
            return await _reposiotry.UpdateRegion(region);
        }

        //Walks services

        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            return await _walks.CreateWalkAsync(walk);
        }

        public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterBy = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pagesize = 1000)
        {
            return await _walks.GetAllWalksAsync(filterOn, filterBy, sortBy, isAscending, pageNumber, pagesize);
        }

        public async Task<Walk?> GetWalk(Guid id)
        {
            return await _walks.GetWalk(id);
        }

        public async Task<Walk> UpdateWalks(Guid walkid, Walk walk)
        {
            return await _walks.UpdateWalks(walkid, walk);
        }

        public async Task<bool> DeleteWalksAsync(Guid id)
        {
            return await _walks.DeleteWalksAsync(id);
        }
    }
}
