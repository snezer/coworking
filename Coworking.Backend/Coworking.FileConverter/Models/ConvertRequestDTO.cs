using Microsoft.AspNetCore.Http;

namespace Coworking.FileConverter.Models
{
    public class ConvertRequestDTO
    {
        public int FloorId { get; set; }
        public IFormFile? FloorLauoutContext { get; set; }

    }
}
