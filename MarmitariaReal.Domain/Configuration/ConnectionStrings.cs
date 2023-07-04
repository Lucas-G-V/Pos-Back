using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmitariaReal.Domain.Configuration
{
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; } = string.Empty;
        public string AzureStorageBlob { get; set; } = string.Empty;
    }
}
