using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YW.HandoverMgmt.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class FileManagementController : ControllerBase
    {
        [HttpPost("uploadfiles")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            foreach (var file in files)
            {
                if(file.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count = files.Count, size });
        }
    }
}
