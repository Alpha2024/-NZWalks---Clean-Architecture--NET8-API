using NZwalks.Core.Domain.Entities;
using NZwalks.Core.Domain.RepositorieInterface;
using NZWalks.API.ServiceContracts;

namespace NZWalks.API.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imagerepository;

        public ImageService(IImageRepository imagerepository)
        {
            _imagerepository = imagerepository;
        }

        public async Task<Image> Upload(Image image)
        {
            return await _imagerepository.Upload(image);
        }
    }
}
