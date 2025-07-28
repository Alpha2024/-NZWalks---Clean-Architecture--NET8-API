

using Microsoft.AspNetCore.Mvc;
using NZwalks.Core.Domain.Entities;
using NZWalks.API.CustomeActionFilters;
using NZWalks.API.Dtos;
using NZWalks.API.ServiceContracts;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _service;

        public ImagesController(IImageService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("UploadFile")]
        [ValidateModel]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            validateFileUpload(imageUploadRequestDto);
            var imagesadded = new Image
            {
                File = imageUploadRequestDto.File,
                FileDescription = imageUploadRequestDto.FileDescription,
                FileName = imageUploadRequestDto.FileName,
                FileExtension = Path.GetExtension(imageUploadRequestDto.File.FileName),
                FileSizeInBytes = imageUploadRequestDto.File.Length,
            };

            await _service.Upload(imagesadded);
            return Ok(imagesadded);
        }

        private void validateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            if (request.File.Length > 2097152)
            {
                ModelState.AddModelError("file", "File Size more than 2MB, please upload a smaller size file");
            }
        }


    }
}
