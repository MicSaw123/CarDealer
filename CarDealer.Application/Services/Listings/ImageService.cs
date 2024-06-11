using CarDealer.Application.Interfaces.Services.Listing;
using CarDealer.Domain.Errors;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace CarDealer.Application.Services.Listings
{
    public class ImageService : IImageService
    {

        string host = "ftp://192.168.0.101/";
        string userName = "Anonymous";
        string password = "mic_saw123@o2.pl";

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

        public async Task<RequestResult<List<byte[]>>> DownloadImagesFromFTP(string directoryName)
        {
            List<string> files = Common.GetImageFilesFromFtpFolder(directoryName);
            List<byte[]> images = new List<byte[]>();
            try
            {
                foreach (var file in files)
                {
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
                        }
                    }
                }
                return RequestResult<List<byte[]>>.Success(images);
            }
            catch
            {
                return RequestResult<List<byte[]>>.Failure(Error.ErrorUnknown);
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
        public static string GetCurrentDirectory()
        {
            var result = Directory.GetCurrentDirectory();
            return result;
        }
        public static string GetStaticContentDirectory()
        {
            var result = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\StaticContent");
            if (!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }
            return result;
        }
        public static string GetFilePath(string fileName)
        {
            var getStaticContentDirectory = GetStaticContentDirectory();
            var result = Path.Combine(getStaticContentDirectory, fileName);
            return result;
        }

        public static bool CreateDirectory(string name)
        {
            string host = "ftp://192.168.0.101/";
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
            string host = "ftp://192.168.0.101/";
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
