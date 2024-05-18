using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.DA.Models
{
    public class FileConverterResult
    {
        public long Id { get; set; }
        public int FloorId { get; set; }
        public string? FloorLayoutContent { get; set; }
        public string? ContentType { get; set; }
    }
}
