using NZwalks.Core.Domain.Entities;



namespace NZwalks.Core.Domain.RepositorieInterface
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegions();
        Task<Region> AddRegion(Region region);
        Task<Region?> GetRegionById(Guid regionId);
        Task<Region> UpdateRegion(Region region);
        Task<bool> DeleteRegion(Guid regionId);

    }
}
