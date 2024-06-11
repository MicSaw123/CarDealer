using Microsoft.AspNetCore.Http;

namespace CarDealer.Application.Interfaces.Services.Listing
{
    public interface IImageService
    {

        Task<RequestResult> UploadImageToFTP(List<IFormFile> fileList, string name);

        Task<RequestResult<List<byte[]>>> DownloadImagesFromFTP(string directoryName);

        Task<RequestResult> DeleteImageFromFTP(string directoryName, string imageName);
    }
}
