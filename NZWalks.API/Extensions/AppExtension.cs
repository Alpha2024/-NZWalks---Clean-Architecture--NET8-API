using NZwalks.Core.Domain.RepositorieInterface;
using NZwalks.Infrasture.Repositories;
using NZWalks.API.ServiceContracts;
using NZWalks.API.Services;
namespace NZWalks.API.Extensions
{
    public static class AppExtension
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceContract, AppServices>();
            services.AddScoped<IRegionRepository, RegionRepositories>();
            services.AddScoped<IWalksRepository, WalksRepositories>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IImageService, ImageService>();
        }
    }
}
