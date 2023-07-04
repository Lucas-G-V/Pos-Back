using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmitariaReal.Domain.ViewModels.Attribute
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public FileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file && value != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"O tamanho máximo do arquivo é {_maxFileSize} bytes.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
