using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pixgram_V1.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        public Guid FileTitle { get; set; }
        public string FilePath { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
