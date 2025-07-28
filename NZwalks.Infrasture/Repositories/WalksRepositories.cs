using Microsoft.EntityFrameworkCore;
using NZwalks.Core.Domain.Entities;
using NZwalks.Core.Domain.RepositorieInterface;
using NZwalks.Infrasture.ApplicationContext;

namespace NZwalks.Infrasture.Repositories
{

    public class WalksRepositories : IWalksRepository
    {
        private readonly AppDbContext _context;

        public WalksRepositories(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            walk.CreatedAt = DateTime.Now;
            walk.IsActive = true;
            walk.IsDeleted = false;
            await _context.walks.AddAsync(walk);
            await _context.SaveChangesAsync();

            return walk;
        }

        public async Task<bool> DeleteWalksAsync(Guid id)
        {
            var walks = await _context.walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walks == null)
            {
                return false;
            }

            walks.IsActive = false;
            walks.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterBy = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks = _context.walks.Include("Difficulty").Include("Region").Where(temp => temp.IsActive == true && temp.IsDeleted == false).AsQueryable();

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterBy) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterBy));
                }
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }
            //Pagination
            var skipResults = (pageNumber - 1) * pageSize;
            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetWalk(Guid id)
        {
            return await _context.walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(temp => temp.Id == id && temp.IsDeleted == false && temp.IsActive == true);
        }

        public async Task<Walk> UpdateWalks(Guid walkid, Walk walk)
        {
            if (walkid == null)
            {
                throw new ArgumentNullException(nameof(walkid));
            }
            var exitingwalks = await _context.walks.FirstOrDefaultAsync(x => x.Id == walkid);
            if (exitingwalks == null)
            {
                throw new Exception("walks not found");
            }
            if (walk == null) throw new ArgumentNullException(nameof(walk));

            exitingwalks.DifficultyId = walk.DifficultyId;
            exitingwalks.Name = walk.Name;
            exitingwalks.RegionId = walk.RegionId;
            exitingwalks.WalkImageUrl = walk.WalkImageUrl;
            exitingwalks.LengthInKm = walk.LengthInKm;
            exitingwalks.Description = walk.Description;
            exitingwalks.IsActive = walk.IsActive;
            exitingwalks.IsDeleted = walk.IsDeleted;
            exitingwalks.LastUpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return exitingwalks;
        }
    }
}
