

using NZwalks.Core.Domain.Entities;

namespace NZwalks.Core.Domain.RepositorieInterface
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
