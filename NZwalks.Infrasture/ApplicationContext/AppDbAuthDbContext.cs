

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZwalks.Infrasture.ApplicationContext
{
    public class AppDbAuthDbContext : IdentityDbContext
    {
        public AppDbAuthDbContext(DbContextOptions<AppDbAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "D76342C8-E220-4DAA-95C4-2C2EFD86ACC0";
            var writerRoleId = "C890FC05-5B75-4FC7-AD89-6E16EA03C23E";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
