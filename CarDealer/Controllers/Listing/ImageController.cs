using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers.Listing
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ApiControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("DownloadImageFromFTP")]
        public async Task<IActionResult> DownloadImageFromFtp(string directoryName)
        {
            var result = await _imageService.DownloadImagesFromFTP(directoryName);
            return CreateResponse(result);
        }

        [HttpPost("UploadImageToFTP")]
        public async Task<IActionResult> UploadImageToFtp(List<IFormFile> imageList, string directoryName)
        {
            var result = await _imageService.UploadImageToFTP(imageList, directoryName);
            return CreateResponse(result);
        }

        [HttpPost("UploadImagesToExistingFTPDirectory")]
        public async Task<IActionResult> UploadImagesToExistingFTPDirectory(List<IFormFile> images, string dirName)
        {
            var result = await _imageService.UploadImagesToExistingFTPDirectory(images, dirName);
            return CreateResponse(result);
        }

        [HttpDelete("DeleteImageFromFTP")]
        public async Task<IActionResult> DeleteImageFromFtp(string directoryName, string fileName)
        {
            var result = await _imageService.DeleteImageFromFTP(directoryName, fileName);
            return CreateResponse(result);
        }

        [HttpDelete("DeleteListingFolder")]
        public async Task<IActionResult> DeleteListingFolder(string dirName)
        {
            var result = await _imageService.DeleteListingFolder(dirName);
            return CreateResponse(result);
        }
    }
}
