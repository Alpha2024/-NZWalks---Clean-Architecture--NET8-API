using NZwalks.Core.Domain.Entities;

namespace NZWalks.API.ServiceContracts
{
    public interface IImageService
    {
        Task<Image> Upload(Image image);
    }
}
