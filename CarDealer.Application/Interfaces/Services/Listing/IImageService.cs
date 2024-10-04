using CarDealer.Application.DataTransferObjects.Dtos.Image;
using Microsoft.AspNetCore.Http;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IImageService
    {

        Task<RequestResult> UploadImageToFTP(List<IFormFile> fileList, string name);

        Task<RequestResult> DeleteListingFolder(string dirName);

        Task<RequestResult<List<ImageDto>>> DownloadImagesFromFTP(string directoryName);

        Task<RequestResult> DeleteImageFromFTP(string directoryName, string imageName);

        Task<RequestResult> UploadImagesToExistingFTPDirectory(List<IFormFile> images, string dirName);

    }
}
