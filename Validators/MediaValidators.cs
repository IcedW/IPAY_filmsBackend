using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace MediaValidators
{
    // Checks the file isn't bigger than the allowed size (in bytes)
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxBytes;

        public MaxFileSizeAttribute(long maxBytes)
        {
            _maxBytes = maxBytes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var file = value as IFormFile;
            if (file != null && file.Length > _maxBytes)
                return new ValidationResult($"File size can't exceed {_maxBytes / 1024 / 1024} MB.");

            return ValidationResult.Success;
        }
    }

    // Checks the file extension is in the allowed list (e.g. ".jpg", ".png")
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(params string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var file = value as IFormFile;
            if (file == null) return ValidationResult.Success;

            var ext = Path.GetExtension(file.FileName);
            if (!_extensions.Contains(ext, System.StringComparer.OrdinalIgnoreCase))
                return new ValidationResult($"Only these file types are allowed: {string.Join(", ", _extensions)}");

            return ValidationResult.Success;
        }
    }
}