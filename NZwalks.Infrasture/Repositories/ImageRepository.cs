using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NZwalks.Core.Domain.Entities;
using NZwalks.Core.Domain.RepositorieInterface;
using NZwalks.Infrasture.ApplicationContext;

namespace NZwalks.Infrasture.Repositories
{
    public class ImageRepository : IImageRepository
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;

        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor, AppDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",
                $"{image.FileName}{image.FileExtension}");
            //upload image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlfilepath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlfilepath;

            //add the image to the images database
            image.IsActive = true;
            image.IsDeleted = false;
            image.CreatedAt = DateTime.Now;

            await _context.images.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }
    }
}
