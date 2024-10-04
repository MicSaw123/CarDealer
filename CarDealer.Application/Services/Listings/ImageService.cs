using CarDealer.Application.DataTransferObjects.Dtos.Image;
using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Domain.Errors;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace CarDealer.Application.Services.Listings
{
    public class ImageService : IImageService
    {

        static string host = "ftp://192.168.1.33/";
        static string userName = "Anonymous";
        static string password = "mic_saw123@o2.pl";

        public async Task<RequestResult> DeleteImageFromFTP(string directoryName, string imageName)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + directoryName + "/" + imageName);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(userName, password);
            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return RequestResult.Success();
                }
            }
            catch
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
        }

        private static void DeleteFilesFromDirectory(string dirName)
        {
            List<string> files = Common.GetImageFilesFromFtpFolder(dirName);
            foreach (var file in files)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + dirName + "/" + file);
                request.Credentials = new NetworkCredential(userName, password);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                var response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
        }

        public async Task<RequestResult> DeleteListingFolder(string dirName)
        {
            DeleteFilesFromDirectory(dirName);
            FtpWebRequest deleteRequest = (FtpWebRequest)WebRequest.Create(host + dirName + "/");
            deleteRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
            deleteRequest.Credentials = new NetworkCredential(userName, password);
            try
            {
                deleteRequest.GetResponse().Close();
                return RequestResult.Success();
            }
            catch
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
        }

        public async Task<RequestResult<List<ImageDto>>> DownloadImagesFromFTP(string directoryName)
        {
            List<string> files = Common.GetImageFilesFromFtpFolder(directoryName);
            List<byte[]> images = new List<byte[]>();
            var id = 1;
            var imageList = new List<ImageDto>();
            try
            {
                foreach (var file in files)
                {
                    var l = new ImageDto();
                    l.Id = id++;
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + directoryName + "/" + file);
                    request.Credentials = new NetworkCredential(userName, password);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            responseStream.CopyTo(memoryStream);
                            byte[] bytes = memoryStream.ToArray();
                            images.Add(bytes);
                            l.Image = bytes;
                            l.ImageName = file;
                            imageList.Add(l);
                        }
                    }
                }
                return RequestResult<List<ImageDto>>.Success(imageList);
            }
            catch
            {
                return RequestResult<List<ImageDto>>.Failure(Error.ErrorUnknown);
            }
        }

        public async Task<RequestResult> UploadImagesToExistingFTPDirectory(List<IFormFile> images, string dirName)
        {
            if (images != null)
            {
                foreach (var image in images)
                {
                    var imageName = image.FileName;
                    var path = host + dirName + "/" + imageName;
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(userName, password);
                    request.KeepAlive = true;
                    request.UsePassive = true;
                    request.UseBinary = true;
                    request.Proxy = null;
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        await image.CopyToAsync(requestStream);
                    }
                }
                return RequestResult.Success();
            }
            else
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
        }

        public async Task<RequestResult> UploadImageToFTP(List<IFormFile> fileList, string name)
        {
            try
            {
                Common.CreateDirectory(name);
                foreach (var file in fileList)
                {
                    var fileName = file.FileName;
                    var path = host + name + "/" + fileName;
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(userName, password);
                    request.KeepAlive = true;
                    request.UsePassive = true;
                    request.UseBinary = true;
                    request.Proxy = null;
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        await file.CopyToAsync(requestStream);
                    }
                }
            }
            catch
            {
                return RequestResult.Failure(Error.ErrorUnknown);
            }
            return RequestResult.Success();
        }

    }
    public class Common
    {
        public static bool CreateDirectory(string name)
        {
            string host = "ftp://192.168.1.33/";
            string UserId = "Anonymous";
            string Password = "mic_saw123@o2.pl";
            bool isCreated = true;
            try
            {
                WebRequest request = WebRequest.Create(host + name);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(UserId, Password);
                using (var response = (FtpWebResponse)request.GetResponse()) ;
            }
            catch
            {
                isCreated = false;
            }
            return isCreated;
        }

        public static List<string> GetImageFilesFromFtpFolder(string folderPath)
        {
            string host = "ftp://192.168.1.33/";
            List<string> imageFiles = new List<string>();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + folderPath);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential("Anonymous", "mic_saw123@o2.pl");
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string fileName = line.Trim();
                imageFiles.Add(fileName);
            }
            reader.Close();
            response.Close();
            return imageFiles;
        }
    }
}
