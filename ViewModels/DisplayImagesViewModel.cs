using Pixgram_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Pixgram_V1.ViewModels
{
    public class DisplayImagesViewModel
    {
        public int Id { get; set; }
        [DisplayName("Namn")]
        public List<FileUpload> FileUpload { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
