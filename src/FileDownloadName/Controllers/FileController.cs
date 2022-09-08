using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileDownloadName.Controllers
{

    [ApiController]
    [Route("/file")]
    public class FileController : ControllerBase
    {
        private const string FileContentTypeDefault = "application/pdf";
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            byte[] pdfBytes = await System.IO.File.ReadAllBytesAsync("../../docs/demo-document.pdf");
                        
            return File(pdfBytes, FileContentTypeDefault);
        }
        
        [HttpGet, Route("/v1/custom-name")]
        public async Task<IActionResult> GetWithCustomName()
        {
            byte[] pdfBytes = await System.IO.File.ReadAllBytesAsync("../../docs/demo-document.pdf");

            string downloadFileName = $"demo-document-{DateTime.Now.ToFileTimeUtc()}";
            
            return File(pdfBytes, FileContentTypeDefault, downloadFileName);
        }
        
        [HttpGet, Route("/v2/custom-name")]
        public async Task<IActionResult> GetV2WithCustomName()
        {
            byte[] pdfBytes = await System.IO.File.ReadAllBytesAsync("../../docs/demo-document.pdf");

            var fileInfo = new System.IO.FileInfo("../../docs/demo-document.pdf");

            return File(pdfBytes, FileContentTypeDefault, fileInfo.Name);
        }
    }
}