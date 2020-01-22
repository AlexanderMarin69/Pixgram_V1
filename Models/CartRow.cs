using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pixgram_V1.Models
{
    [Table("OrderRows")] //We don't want this table to be named "CartRow"
    public class CartRow
    {
        public int Id { get; set; }
        public FileUpload FileUpload { get; set; }
        public int Quantity { get; set; }
    }
}
