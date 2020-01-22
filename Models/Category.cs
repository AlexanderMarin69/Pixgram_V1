using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pixgram_V1.Models
{
    public class Category 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //TODO: ask if needed or if its ok like .Where(category id == dropdownSelectedId)
        //public virtual List<FileUpload> FileUpload { get; set; }

    }
}
