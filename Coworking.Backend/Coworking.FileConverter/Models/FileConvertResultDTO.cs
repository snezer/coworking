using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.FileConverter.Models
{
    public class FileConvertResultDTO
    {
        public int FloorId { get; set; }
        public string? FloorLayoutContent { get; set; }
        public string? ContentType {  get; set; }
    }
}
