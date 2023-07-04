using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmitariaReal.Domain.Configuration
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
        public AzureStorageBlobOptions AzureStorageBlobOptions { get; set; } = new AzureStorageBlobOptions();
    }
}
