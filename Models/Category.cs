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
        public string AssociatedImageGuid { get; set; }
    }
}
