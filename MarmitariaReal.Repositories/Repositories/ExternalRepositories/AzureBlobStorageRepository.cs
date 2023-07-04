using Azure.Identity;
using Azure.Storage.Blobs;
using MarmitariaReal.Domain.Configuration;
using MarmitariaReal.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmitariaReal.Repositories.Repositories.ExternalRepositories
{
    public class AzureBlobStorageRepository : IAzureBlobStorageRepository
    {
        private AppSettings _appSettings;
        public AzureBlobStorageRepository(AppSettings appSettings) 
        { 
            _appSettings = appSettings;
        }

        public async Task<string> UploadFileToStorage(Stream stream, string fileName, string container)
        {
            var blobServiceClient = new BlobServiceClient(_appSettings.ConnectionStrings.AzureStorageBlob);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(container);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(stream, true);

            return blobClient.Uri.AbsoluteUri;
        }

        public async Task DeleteBlobFromUri(string blobUri)
        {
            var blobServiceClient = new BlobServiceClient(_appSettings.ConnectionStrings.AzureStorageBlob);
            var blobContainerUri = new Uri(blobUri);
            var blobContainerName = blobContainerUri.Segments[1].TrimEnd('/'); // Obtém o nome do contêiner da URI

            var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(blobContainerUri.Segments[2].TrimEnd('/'));
            try
            {
                await blobClient.DeleteAsync();
            }
            catch (Exception ex)
            {
                var stop = ex.Message;
            }
            
        }
    }
}
