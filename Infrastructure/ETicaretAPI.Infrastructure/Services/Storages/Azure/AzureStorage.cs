using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ETicaretAPI.Application.Abstraction.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storages.Azure
{
    public class AzureStorage : Storage, IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;  //Azure Storage account'a bağlanmayı sağlar.
        BlobContainerClient _blobcontainerClient;       //Hedef container'da dosya işlemleri yapmayı sağlar.
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }
        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobcontainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobcontainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _blobcontainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobcontainerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobcontainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobcontainerClient.GetBlobs().Any(b => b.Name == fileName);
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            _blobcontainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobcontainerClient.CreateIfNotExistsAsync();
            await _blobcontainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainerName)> datas = new();
            foreach (IFormFile file in files)
            {
               string fileNewName= await FileRenameAsync(containerName, file.Name, HasFile);

                BlobClient blobClient = _blobcontainerClient.GetBlobClient(fileNewName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((fileNewName,$"{containerName}/{fileNewName}" ));
            }
            return datas;
        }
    }
}
