using Microsoft.AspNetCore.Mvc.Rendering;
using Pixgram_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pixgram_V1.ViewModels
{
    public class ImageUploadViewModel
    {

        public Image Image { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public List<FileUpload> FileUpload { get; set; }
    }
}
