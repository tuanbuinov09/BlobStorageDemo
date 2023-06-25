using Azure.Storage.Blobs;
using BlobStorageDemo.Models;
using System.IO;

namespace BlobStorageDemo.Services
{
    public class FileService : IFileService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public FileService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(FileModel fileModel)
        {
            var container = _blobServiceClient.GetBlobContainerClient("containerName");

            var blob = container.GetBlobClient(fileModel.File.FileName + DateTime.Now + Guid.NewGuid());

            await blob.UploadAsync(fileModel.File.OpenReadStream());
        }

        public async Task<Stream> Get(string fileName)
        {
            var container = _blobServiceClient.GetBlobContainerClient("containerName");

            var blob = container.GetBlobClient(fileName);

            var downloadableFile = await blob.DownloadAsync();

            return downloadableFile.Value.Content;

        }
    }
}
