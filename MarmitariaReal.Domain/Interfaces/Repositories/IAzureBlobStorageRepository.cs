using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmitariaReal.Domain.Interfaces.Repositories
{
    public interface IAzureBlobStorageRepository
    {
        Task<string> UploadFileToStorage(Stream stream, string fileName, string container);
        Task DeleteBlobFromUri(string blobUri);
    }
}
