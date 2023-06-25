using BlobStorageDemo.Models;

namespace BlobStorageDemo.Services
{
    public interface IFileService
    {
        Task Upload(FileModel fileModel);

        Task<Stream> Get(string fileName);
    }
}
