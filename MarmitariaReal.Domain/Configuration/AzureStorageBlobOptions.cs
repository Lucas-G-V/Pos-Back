using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmitariaReal.Domain.Configuration
{
    public class AzureStorageBlobOptions
    {
        public string DefaultConnection { get; set; } =string.Empty;
        public string ContainerReceitas { get; set; } = string.Empty;
    }
}
