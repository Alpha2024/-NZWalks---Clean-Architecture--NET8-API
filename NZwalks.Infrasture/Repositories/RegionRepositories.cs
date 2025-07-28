

using Microsoft.EntityFrameworkCore;
using NZwalks.Core.Domain.Entities;
using NZwalks.Core.Domain.RepositorieInterface;
using NZwalks.Infrasture.ApplicationContext;

namespace NZwalks.Infrasture.Repositories
{

    public class RegionRepositories : IRegionRepository
    {
        private readonly AppDbContext _context;

        public RegionRepositories(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Region> AddRegion(Region region)
        {
            region.CreatedAt = DateTime.UtcNow;
            region.IsDeleted = false;
            region.IsActive = true;
            await _context.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<bool> DeleteRegion(Guid regionId)
        {
            var region = await _context.regions.FirstOrDefaultAsync(temp => temp.Id == regionId);
            if (region == null)
            {
                return false;
            }

            region.IsDeleted = true;
            region.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Region>> GetAllRegions()
        {
            return await _context.regions.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
        }

        public async Task<Region?> GetRegionById(Guid regionId)
        {
            return await _context.regions.FirstOrDefaultAsync(temp => temp.Id == regionId && temp.IsDeleted == false && temp.IsActive == true);
        }

        public async Task<Region> UpdateRegion(Region region)
        {
            region.IsDeleted = false;
            region.IsActive = true;
            region.LastUpdatedAt = DateTime.UtcNow;
            _context.Update(region);
            await _context.SaveChangesAsync();
            return region;
        }
    }
}
