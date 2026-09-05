using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaValidators.Example
{
    public class MediaUploadModel
    {
        [Required]
        [MaxFileSize(5 * 1024 * 1024)] // 5 MB
        [AllowedExtensions(".jpg", ".jpeg", ".png")]
        public IFormFile Image { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        [HttpPost("upload")]
        public IActionResult Upload([FromForm] MediaUploadModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // save model.Image here...
            return Ok("Upload successful");
        }
    }
}
