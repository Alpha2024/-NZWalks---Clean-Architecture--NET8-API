using NZwalks.Core.Domain.Entities;


namespace NZwalks.Core.Domain.RepositorieInterface
{
    public interface IWalksRepository
    {
        Task<Walk> CreateWalkAsync(Walk walk);
        Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterBy = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pagesize = 1000);
        Task<Walk?> GetWalk(Guid id);
        Task<Walk> UpdateWalks(Guid walkid, Walk walk);
        Task<bool> DeleteWalksAsync(Guid id);
    }
}
