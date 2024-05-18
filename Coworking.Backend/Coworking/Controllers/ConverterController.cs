using Coworking.FileConverter;
using Coworking.FileConverter.Models;
using Coworking.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly ILogger<ConverterController> _logger;

        public ConverterController(ILogger<ConverterController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("PngSvgComnvertFile")]
        public IActionResult PngSvgComnvertFile(ConvertRequestDTO request)
        {
            if (filePath == null)
            {
                _logger.LogInformation("Файл не был передан в метод.");
                return StatusCode(400, "Файл не был передан в метод.");
            }

            try
            {

                

                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, $"Ошибка конвертации файла: {err.Message}");
                return StatusCode(400, err);
            }
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok(DateTime.Now);
        }
    }
}
