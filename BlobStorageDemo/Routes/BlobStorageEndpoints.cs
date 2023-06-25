using BlobStorageDemo.Models;
using BlobStorageDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorageDemo.Routes
{
    public static class BlobStorageEndpoints
    {
        public static void MapBlobStorageEndpoints(this WebApplication app)
        {
            var blobGroup = app.MapGroup("Blob").WithTags("Blob");

            blobGroup.MapPost("/upload", async ([FromForm] FileModel fileModel, IFileService fileService) =>
            {
                await fileService.Upload(fileModel);
                return Results.Ok("upload successfully");
            });

            blobGroup.MapGet("/get", async (string fileName, IFileService fileService) =>
            {
                var fileStream = await fileService.Get(fileName);
                string fileType = fileName.Substring(fileName.LastIndexOf(".", fileName.Length));
                return Results.File(fileStream: fileStream, contentType: $"image/{fileType}", fileDownloadName: fileName);
            });

            blobGroup.MapGet("/download", async (string fileName, IFileService fileService) =>
            {
                var fileStream = await fileService.Get(fileName);
                string fileType = fileName.Substring(fileName.LastIndexOf(".", fileName.Length));
                return Results.File(fileStream: fileStream, contentType: $"image/{fileType}", fileDownloadName: fileName);
            });
        }
    }
}
