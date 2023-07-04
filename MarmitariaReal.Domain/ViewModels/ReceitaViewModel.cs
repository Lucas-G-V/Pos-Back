using MarmitariaReal.Domain.ViewModels.Attribute;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmitariaReal.Domain.ViewModels
{
    public class ReceitaViewModel
    {
        public Guid ReceitaId { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Descricao { get; set; }
        [Required]
        [FileSize(1048576)]
        public IFormFile Imagens { get; set; }
        public string UrlImagem { get; set; } = string.Empty;
        [Required]
        public double Preco { get; set; }
    }
}
