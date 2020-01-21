using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pixgram_V1.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileCategory { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual List<FileUpload> FileUpload { get; set; }
        public string ImageUrl { get; set; }
    }
}
