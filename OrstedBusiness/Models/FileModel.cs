using Microsoft.AspNetCore.Http;

namespace OrstedBusiness.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile? File { get; set; }
    }
}
